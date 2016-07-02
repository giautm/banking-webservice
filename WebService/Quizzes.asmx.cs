using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;

namespace BankingWebService
{
    /// <summary>
    /// Summary description for Quizzes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Quizzes : System.Web.Services.WebService
    {
        private ModelsContext mContext = new ModelsContext();

        public class BasicResult
        {
            public string SessionToken;
            public string MessageError;

            public override string ToString()
            {
                return string.Format("Token: {0}, error message: {1}", SessionToken, MessageError);
            }
        }

        public long? _checkSessionToken(string sessionToken, BasicResult result)
        {
            if (sessionToken == null)
            {
                return null;
            }

            var now = DateTime.Now;
            var session = mContext.UserSession
                .Where(s => s.SessionToken.Equals(sessionToken) && s.IsActived
                  && (s.ExpiresAt.HasValue && DateTime.Compare(s.ExpiresAt.Value, now) > 0))
                .FirstOrDefault();

            if (session != null)
            {
                // Cập nhật lại thời gian hết hạn của phiên.
                session.refresh();
                mContext.SaveChanges();

                // Cập nhật lại Session Token nếu có thay đổi.
                result.SessionToken = session.SessionToken;

                return session.UserId;
            }
            else
            {
                // Cập nhật lại Session Token nếu có thay đổi.
                result.SessionToken = null;
                result.MessageError = "Phiên đã hết hạn hoặc không tồn tại. Vui lòng đăng nhập lại.";

                return null;
            }
        }

        public string _hashUserPassword(string password, string salt)
        {
            byte[] bytes = new UTF8Encoding().GetBytes(password + salt);
            byte[] hash = (CryptoConfig.CreateFromName("MD5") as HashAlgorithm)
              .ComputeHash(bytes);

            // string representation (similar to UNIX format)
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
        }

        [WebMethod]
        public BasicResult Register(Models.User user)
        {
            var result = new BasicResult();
            var readyExists = mContext.User
              .Where(u => u.Username == user.Username).Count() > 0;
            if (readyExists)
            {
                result.MessageError = "Tài khoản đã tồn tại";
            }
            else
            {
                user.Id = 0;
                // TODO: Generate password salt.
                user.Salt = "giautm";
                user.Password = _hashUserPassword(user.Password, user.Salt);
                user.CreatedAt = DateTime.Now;
                mContext.User.Add(user);
                mContext.SaveChanges();

                var currentSession = new Models.UserSession(user.Id);
                mContext.UserSession.Add(currentSession);
                mContext.UserAccount.Add(new Models.UserAccount(user.Id));
                mContext.SaveChanges();

                result.SessionToken = currentSession.SessionToken;
            }

            return result;
        }

        [WebMethod]
        public BasicResult Login(string username, string password)
        {
            var result = new BasicResult();
            var user = mContext.User
              .Where(u => u.Username.Equals(username))
              .FirstOrDefault();

            if (user != null && user.Id > 0 &&
              user.Password.Equals(_hashUserPassword(password, user.Salt)))
            {
                var session = mContext.UserSession.Add(new Models.UserSession(user.Id));
                mContext.SaveChanges();

                result.SessionToken = session.SessionToken;
            }
            else
            {
                result.MessageError = "Tên đăng nhập hoặc mật khẩu không chính xác.";
            }

            return result;
        }

        [WebMethod]
        public void Logout(string sessionToken)
        {
            var session = mContext.UserSession
                .Where(s => s.SessionToken.Equals(sessionToken) && s.IsActived)
                .FirstOrDefault();

            if (session != null)
            {
                session.IsActived = false;
                mContext.SaveChanges();
            }
        }


        [WebMethod]
        public BasicResult MakeExam(string sessionToken, Models.Exam exam, int numberOf)
        {
            var result = new BasicResult();
            var userId = _checkSessionToken(sessionToken, result);

            if (userId.HasValue)
            {
                var quizzesId = mContext.Quizzes
                    .Where(q => q.Subject.Equals(exam.Subject))
                    .Select(q => q.Id)
                    .ToArray();
                var count = quizzesId.Length;
                if (count > numberOf)
                {
                    var idies = new long[numberOf];
                    var random = new Random();
                    while (numberOf > 0)
                    {
                        var idx = quizzesId[random.Next(0, count)];
                        if (idies.Contains(idx) == false)
                        {
                            idies[--numberOf] = idx;
                        }
                    }

                    exam.Quizzes = string.Join(",", idies.Select(x => x.ToString()).ToArray());

                    mContext.Exam.Add(exam);
                    mContext.SaveChanges();
                }
                else
                {
                    result.MessageError = string.Format("Số lượng câu hỏi lớn hơn số lượng câu hỏi trong CSDL.");
                }
            }

            return result;
        }

        public class ExamListResult : BasicResult
        {
            public List<Models.Exam> Exams;
        }

        [WebMethod]
        public ExamListResult GetExamList(string sessionToken)
        {
            var result = new ExamListResult();
            var userId = _checkSessionToken(sessionToken, result);
            if (userId.HasValue)
            {
                result.Exams = mContext.Exam.ToList();
            }

            return result;
        }

        public class QuizzesResult : BasicResult
        {
            public Models.AnswerSheet AnswerSheet;
            public long Index;
            public string Question;
            public string Answer;
            public string ChooseA;
            public string ChooseB;
            public string ChooseC;
            public string ChooseD;
        }

        [WebMethod]
        public QuizzesResult NextQuizzes(string sessionToken, Models.AnswerSheet answerSheet)
        {
            var result = new QuizzesResult();
            var userID = _checkSessionToken(sessionToken, result);
            var exam = mContext.Exam.FirstOrDefault(e => e.Id == answerSheet.ExamId);
            if (userID.HasValue && exam != null)
            {
                var quizzesIds = exam.Quizzes.Split(new char[] { ',' })
                    .Select(id => int.Parse(id)).ToArray();

                var index = 0;
                var nextQuizzes = 0;
                for (int i = 0; i < quizzesIds.Length; ++i)
                {
                    if (answerSheet.CurrentQuizzes.HasValue == false ||
                        answerSheet.CurrentQuizzes == 0 ||
                        answerSheet.CurrentQuizzes == quizzesIds[i])
                    {
                        nextQuizzes = quizzesIds[++i < quizzesIds.Length ? i : 0];
                        index = i;
                        break;
                    }
                }

                answerSheet.CurrentQuizzes = nextQuizzes;
                mContext.SaveChanges();

                var quizzes = mContext.Quizzes.FirstOrDefault(q => q.Id == nextQuizzes);
                if (quizzes != null)
                {
                    result.AnswerSheet = answerSheet;
                    result.Index = index;
                    result.Question = quizzes.Question;
                    result.ChooseA = quizzes.ChooseA;
                    result.ChooseB = quizzes.ChooseB;
                    result.ChooseC = quizzes.ChooseC;
                    result.ChooseD = quizzes.ChooseD;

                    result.Answer = mContext.AnswerSheetItem
                        .Where(ai => ai.AnswerSheetId == answerSheet.Id && ai.QuizzesId == nextQuizzes)
                        .Select(ai => ai.Answer)
                        .FirstOrDefault();
                }
                else
                {
                    result.MessageError = string.Format("Không tìm thấy câu hỏi. :(");
                }
            }

            return result;
        }

        public class AnswerSheetResult : BasicResult
        {
            public Models.AnswerSheet AnswerSheet;
        }

        [WebMethod]
        public AnswerSheetResult MakeAnswerSheet(string sessionToken, Models.AnswerSheet answerSheet)
        {
            var result = new AnswerSheetResult();

            var userID = _checkSessionToken(sessionToken, result);
            if (userID.HasValue && mContext.Exam.FirstOrDefault(e => e.Id == answerSheet.ExamId) != null)
            {
                answerSheet.Id = 0;
                answerSheet.UserId = userID.Value;
                answerSheet.Score = 0;
                answerSheet.IsClosed = false;
                answerSheet.CreatedAt = DateTime.Now;

                mContext.AnswerSheet.Add(answerSheet);
                mContext.SaveChanges();

                result.AnswerSheet = answerSheet;
            }
            else
            {
                result.MessageError = string.Format("Không tìm thấy đề thi!");
            }

            return result;
        }

        [WebMethod]
        public BasicResult Answer(string sessionToken, Models.AnswerSheet answerSheet, long quizzesId, string answer)
        {
            var result = new BasicResult();
            var userId = _checkSessionToken(sessionToken, result);
            var ans = mContext.AnswerSheet.FirstOrDefault(a => a.Id == answerSheet.Id && a.UserId == userId);
            if (ans != null)
            {
                var exam = mContext.Exam.FirstOrDefault(e => e.Id == ans.ExamId);
                var deadline = ans.CreatedAt.AddMinutes(exam.Time);
                if (deadline <= DateTime.Now)
                {
                    ans.IsClosed = true;
                }

                var quizzesIds = exam.Quizzes.Split(new char[] { ',' });
                if (ans.IsClosed == true)
                {
                    result.MessageError = string.Format("Bài kiểm tra đã được đóng, không thể tiếp tục");

                    var answers = mContext.AnswerSheetItem
                        .Where(ai => ai.AnswerSheetId == ans.Id).ToArray();
                    ans.Score = answers.Select(i => i.Match ? 1.0 : 0.0).Sum() / answers.Length;

                    mContext.SaveChanges();
                }
                else if (quizzesIds.Any(q => q == quizzesId.ToString()))
                {
                    var answerItem = mContext.AnswerSheetItem
                        .FirstOrDefault(ai => ai.AnswerSheetId == ans.Id && ai.QuizzesId == quizzesId);
                    if (answerItem == null)
                    {
                        answerItem = new Models.AnswerSheetItem()
                        {
                            AnswerSheetId = ans.Id,
                            QuizzesId = quizzesId,
                            Answer = answer,
                            Match = false
                        };
                        mContext.AnswerSheetItem.Add(answerItem);
                    }

                    var quizzes = mContext.Quizzes.FirstOrDefault(q => q.Id == quizzesId);
                    answerItem.Match = quizzes != null ? quizzes.Answer.Trim() == answer.Trim() : false;

                    mContext.SaveChanges();
                }
                else
                {
                    result.MessageError = string.Format("Câu hỏi không có trong đề thi!");
                }
            }

            return result;
        }

        public class DoneAnswerSheetResult : BasicResult
        {
            public Models.AnswerSheet AnswerSheet;
        }

        [WebMethod]
        public DoneAnswerSheetResult DoneAnswerSheet(string sessionToken, Models.AnswerSheet answerSheet)
        {
            var result = new DoneAnswerSheetResult();
            var userId = _checkSessionToken(sessionToken, result);
            var ans = mContext.AnswerSheet.FirstOrDefault(a => a.Id == answerSheet.Id && a.UserId == userId);
            if (ans != null)
            {
                var answers = mContext.AnswerSheetItem
                    .Where(ai => ai.AnswerSheetId == ans.Id).ToArray();
                ans.IsClosed = true;
                ans.Score = Math.Round((answers.Select(i => i.Match ? 1.0 : 0.0).Sum() / answers.Length) * 10, 1);

                mContext.SaveChanges();

                result.AnswerSheet = ans;
            }

            return result;
        }

        public class LastAnswerSheetResult : BasicResult
        {
            public Models.AnswerSheet AnswerSheet;
            public Models.Exam Exam;
        }

        [WebMethod]
        public LastAnswerSheetResult GetLastAnswerSheet(string sessionToken)
        {
            var result = new LastAnswerSheetResult();
            var userId = _checkSessionToken(sessionToken, result);
            if (userId.HasValue)
            {
                var answerSheets = mContext.AnswerSheet
                    .Where(a => a.IsClosed != true && a.UserId == userId)
                    .OrderByDescending(a => a.Id)
                    .ToArray();

                Models.AnswerSheet lastAnswerSheet = null;
                Models.Exam lastExam = null;

                foreach (var item in answerSheets)
                {
                    var exam = mContext.Exam.FirstOrDefault(e => e.Id == item.ExamId);
                    if (exam != null)
                    {
                        var deadline = item.CreatedAt.AddMinutes(exam.Time);
                        if (deadline < DateTime.Now && lastAnswerSheet == null)
                        {
                            lastAnswerSheet = item;
                            lastExam = exam;
                        }
                        else
                        {
                            item.IsClosed = true;
                        }
                    }
                }

                mContext.SaveChanges();

                result.AnswerSheet = lastAnswerSheet;
                result.Exam = lastExam;
            }

            return result;
        }
    }
}
