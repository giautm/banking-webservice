using Quizzes.QuizzesService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzes
{
    public partial class Form1 : Form
    {
        private QuizzesSoapClient mQuizzes;
        private string MessageBoxTitle;
        private string mSessionToken;
        private AnswerSheet mAnswerSheet;
        private double mLeftTime;

        public Form1()
        {
            InitializeComponent();
            mQuizzes = new QuizzesSoapClient();
            MessageBoxTitle = "Trắc nghiệm";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showAnswer(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var service = new QuizzesSoapClient();
            service.MakeAnswerSheet(mSessionToken, new AnswerSheet()
            {
                FirstName = "Giau",
                LastName = "Trần Minh",
                ExamId = 1,
                Score = 100
            });

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            double time = 0;
            if (!double.TryParse(txtExamTime.Text, out time) && time <= 0)
            {
                MessageBox.Show(string.Format("Thời gian thi {0} không hợp lệ!", txtExamTime.Text));
                return;
            }

            int numberOf = 0;
            if (!int.TryParse(txtExamNumberOf.Text, out numberOf) && numberOf <= 0)
            {
                MessageBox.Show(string.Format("Số câu hỏi {0} không hợp lệ!", txtExamNumberOf.Text));
                return;
            }

            var title = txtExamTitle.Text.Trim();
            if (title.Length == 0)
            {
                MessageBox.Show(string.Format("Cần nhập tên đề thi!"));
                return;
            }

            var result = mQuizzes.MakeExam(mSessionToken, new Exam()
            {
                Subject = cbExamSubject.SelectedItem.ToString(),
                Time = time,
                Title = title
            }, numberOf);

            if (result.MessageError == null)
            {
                MessageBox.Show("Thêm đề thi mới thành công!");
            }
            else
            {
                MessageBox.Show(result.MessageError);
            }
            UpdateExamList();
        }

        private void UpdateExamList()
        {
            var result = mQuizzes.GetExamList(mSessionToken);
            if (result.MessageError != null)
            {
                MessageBox.Show(result.MessageError, MessageBoxTitle);
                return;
            }

            cbExam.Items.Clear();
            foreach (var item in result.Exams)
            {
                cbExam.Items.Add(new ComboboxItem()
                {
                    Text = item.Title,
                    Value = item
                });
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var result = mQuizzes.Login(txtUsername.Text, txtPassword.Text);
            if (result.MessageError != null)
            {
                MessageBox.Show(result.MessageError, this.MessageBoxTitle);
                btnLogin.Enabled = true;
                btnLogout.Enabled = false;
                return;
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công!");
                this.mSessionToken = result.SessionToken;
                btnLogin.Enabled = false;
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
                btnLogout.Enabled = true;

                UpdateExamList();

                var result2 = mQuizzes.GetLastAnswerSheet(mSessionToken);
                if (result2.AnswerSheet != null && result2.Exam != null)
                {
                    initAnswerSheetTimer(result2.AnswerSheet, result2.Exam);
                    mAnswerSheet = result2.AnswerSheet;

                    loadNextQuizzes();

                    txtFirstName.Text = mAnswerSheet.FirstName;
                    txtLastName.Text = mAnswerSheet.LastName;

                    showRegister(false);
                    showAnswer(true);
                }
                else
                {
                    showRegister(true);
                    showAnswer(false);
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            mQuizzes.Logout(mSessionToken);
            mSessionToken = null;
            btnLogin.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnRegisterExam_Click(object sender, EventArgs e)
        {
            var exam = (cbExam.SelectedItem as ComboboxItem).Value as Exam;
            var result = mQuizzes.MakeAnswerSheet(mSessionToken, new AnswerSheet()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                ExamId = exam.Id,
            });

            if (result.MessageError != null)
            {
                MessageBox.Show(result.MessageError, this.MessageBoxTitle);
                return;
            }
            else
            {
                mAnswerSheet = result.AnswerSheet;
                MessageBox.Show(string.Format("Đăng kí thi thành công, môn thi {0}, thời gian làm bài {1} phút",
                    exam.Subject, exam.Time));

                loadNextQuizzes();
                showRegister(false);
                showAnswer(true);
                initAnswerSheetTimer(mAnswerSheet, exam);
            }
        }

        private void initAnswerSheetTimer(AnswerSheet answerSheet, Exam exam)
        {
            mLeftTime = exam.Time - (DateTime.Now - answerSheet.CreatedAt).TotalMinutes;
            timerAnswerSheet.Interval = 1000;
            timerAnswerSheet.Start();
        }

        private void timerAnswerSheet_Tick(object sender, EventArgs e)
        {
            mLeftTime -= 1.0 / 60;
            if (mLeftTime <= 0)
            {
                timerAnswerSheet.Stop();

                var result = mQuizzes.DoneAnswerSheet(mSessionToken, mAnswerSheet);
                if (result.MessageError != null)
                {
                    MessageBox.Show(result.MessageError, this.MessageBoxTitle);
                    return;
                }
                else
                {
                    MessageBox.Show(string.Format("Đã nộp bài thành công!\r\nĐiểm số: {0}",
                        result.AnswerSheet.Score), this.MessageBoxTitle);
                }
            }
            else
            {
                lbLeftTime.Text = string.Format("Thời gian còn lại: {0} phút, {1} giây",
                    (int)mLeftTime, Math.Round((mLeftTime - ((int)mLeftTime)) * 60, 0));
            }
        }

        private void loadNextQuizzes()
        {
            var result = mQuizzes.NextQuizzes(mSessionToken, mAnswerSheet);
            if (result.MessageError != null)
            {
                MessageBox.Show(result.MessageError, this.MessageBoxTitle);
                return;
            }
            else
            {
                lbQuestion.Text = string.Format("Câu số {0}: {1}", result.Index, result.Question);

                rbChooseA.Text = string.Format("A. {0}", result.ChooseA);
                rbChooseB.Text = string.Format("B. {0}", result.ChooseB);
                rbChooseC.Text = string.Format("C. {0}", result.ChooseC);
                rbChooseD.Text = string.Format("D. {0}", result.ChooseD);

                if (result.Answer != null)
                {
                    rbChooseA.Checked = result.Answer.Equals("A");
                    rbChooseB.Checked = result.Answer.Equals("B");
                    rbChooseC.Checked = result.Answer.Equals("C");
                    rbChooseD.Checked = result.Answer.Equals("D");
                }
                else
                {
                    rbChooseA.Checked = false;
                    rbChooseB.Checked = false;
                    rbChooseC.Checked = false;
                    rbChooseD.Checked = false;
                }

                mAnswerSheet = result.AnswerSheet;
            }
        }
        private void showRegister(bool enabled)
        {
            cbExam.Enabled = enabled;
            txtFirstName.Enabled = enabled;
            txtLastName.Enabled = enabled;
            btnRegisterExam.Enabled = enabled;
        }

        private void btnNextQuizzes_Click(object sender, EventArgs e)
        {
            if (mAnswerSheet != null && mAnswerSheet.IsClosed == false)
            {
                var answer = string.Empty;
                if (rbChooseA.Checked) answer = "A";
                if (rbChooseB.Checked) answer = "B";
                if (rbChooseC.Checked) answer = "C";
                if (rbChooseD.Checked) answer = "D";

                var result = mQuizzes.Answer(mSessionToken, mAnswerSheet,
                    mAnswerSheet.CurrentQuizzes.Value, answer);

                if (result.MessageError != null)
                {
                    MessageBox.Show(result.MessageError, this.MessageBoxTitle);
                    return;
                }
            }

            loadNextQuizzes();
        }

        private void showAnswer(bool enabled)
        {
            rbChooseA.Enabled = enabled;
            rbChooseB.Enabled = enabled;
            rbChooseC.Enabled = enabled;
            rbChooseD.Enabled = enabled;
            btnDone.Enabled = enabled;
            btnNextQuizzes.Enabled = enabled;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            var answer = string.Empty;
            if (rbChooseA.Checked) answer = "A";
            if (rbChooseB.Checked) answer = "B";
            if (rbChooseC.Checked) answer = "C";
            if (rbChooseD.Checked) answer = "D";

            mQuizzes.Answer(mSessionToken, mAnswerSheet,
                mAnswerSheet.CurrentQuizzes.Value, answer);

            var result = mQuizzes.DoneAnswerSheet(mSessionToken, mAnswerSheet);
            if (result.MessageError != null)
            {
                MessageBox.Show(result.MessageError, this.MessageBoxTitle);
                return;
            }
            else
            {
                MessageBox.Show(string.Format("Đã nộp bài thành công!\r\nĐiểm số: {0}",
                    result.AnswerSheet.Score), this.MessageBoxTitle);
            }
            showAnswer(false);
        }
    }

    public class ComboboxItem
    {
        public object Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
