namespace Quizzes
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtExamTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddExam = new System.Windows.Forms.Button();
            this.txtExamTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExamNumberOf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbExamSubject = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRegisterExam = new System.Windows.Forms.Button();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.cbExam = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbChooseD = new System.Windows.Forms.RadioButton();
            this.rbChooseB = new System.Windows.Forms.RadioButton();
            this.rbChooseC = new System.Windows.Forms.RadioButton();
            this.rbChooseA = new System.Windows.Forms.RadioButton();
            this.lbQuestion = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnNextQuizzes = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtExamTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnAddExam);
            this.groupBox1.Controls.Add(this.txtExamTitle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtExamNumberOf);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbExamSubject);
            this.groupBox1.Location = new System.Drawing.Point(242, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm đề thi";
            // 
            // txtExamTime
            // 
            this.txtExamTime.Location = new System.Drawing.Point(99, 52);
            this.txtExamTime.Name = "txtExamTime";
            this.txtExamTime.Size = new System.Drawing.Size(112, 20);
            this.txtExamTime.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Thời gian làm bài";
            // 
            // btnAddExam
            // 
            this.btnAddExam.Location = new System.Drawing.Point(318, 78);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.Size = new System.Drawing.Size(75, 23);
            this.btnAddExam.TabIndex = 6;
            this.btnAddExam.Text = "Thêm mới";
            this.btnAddExam.UseVisualStyleBackColor = true;
            this.btnAddExam.Click += new System.EventHandler(this.btnAddExam_Click);
            // 
            // txtExamTitle
            // 
            this.txtExamTitle.Location = new System.Drawing.Point(281, 52);
            this.txtExamTitle.Name = "txtExamTitle";
            this.txtExamTitle.Size = new System.Drawing.Size(112, 20);
            this.txtExamTitle.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tiêu đề";
            // 
            // txtExamNumberOf
            // 
            this.txtExamNumberOf.Location = new System.Drawing.Point(281, 29);
            this.txtExamNumberOf.Name = "txtExamNumberOf";
            this.txtExamNumberOf.Size = new System.Drawing.Size(112, 20);
            this.txtExamNumberOf.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số câu hỏi";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Môn học";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbExamSubject
            // 
            this.cbExamSubject.FormattingEnabled = true;
            this.cbExamSubject.Items.AddRange(new object[] {
            "SINH_HOC",
            "HOA_HOC",
            "TIENG_ANH"});
            this.cbExamSubject.Location = new System.Drawing.Point(99, 29);
            this.cbExamSubject.Name = "cbExamSubject";
            this.cbExamSubject.Size = new System.Drawing.Size(112, 21);
            this.cbExamSubject.TabIndex = 0;
            this.cbExamSubject.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLogout);
            this.groupBox2.Controls.Add(this.btnLogin);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 113);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đăng nhập";
            // 
            // btnLogout
            // 
            this.btnLogout.Enabled = false;
            this.btnLogout.Location = new System.Drawing.Point(136, 78);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 14;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(9, 78);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(99, 52);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(112, 20);
            this.txtPassword.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mật khẩu";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(99, 29);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(112, 20);
            this.txtUsername.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tên đăng nhập";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRegisterExam);
            this.groupBox3.Controls.Add(this.txtFirstName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtLastName);
            this.groupBox3.Controls.Add(this.cbExam);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(12, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(640, 82);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Đăng kí thi";
            // 
            // btnRegisterExam
            // 
            this.btnRegisterExam.Location = new System.Drawing.Point(548, 46);
            this.btnRegisterExam.Name = "btnRegisterExam";
            this.btnRegisterExam.Size = new System.Drawing.Size(75, 23);
            this.btnRegisterExam.TabIndex = 13;
            this.btnRegisterExam.Text = "Đăng kí thi";
            this.btnRegisterExam.UseVisualStyleBackColor = true;
            this.btnRegisterExam.Click += new System.EventHandler(this.btnRegisterExam_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(305, 19);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(112, 20);
            this.txtFirstName.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Đề thi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(217, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Tên";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(511, 20);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(112, 20);
            this.txtLastName.TabIndex = 10;
            // 
            // cbExam
            // 
            this.cbExam.FormattingEnabled = true;
            this.cbExam.Items.AddRange(new object[] {
            "SINH_HOC",
            "HOA_HOC",
            "TIENG_ANH"});
            this.cbExam.Location = new System.Drawing.Point(99, 19);
            this.cbExam.Name = "cbExam";
            this.cbExam.Size = new System.Drawing.Size(112, 21);
            this.cbExam.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(423, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Họ và tên lót";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.lbQuestion);
            this.groupBox4.Controls.Add(this.btnDone);
            this.groupBox4.Controls.Add(this.btnNextQuizzes);
            this.groupBox4.Location = new System.Drawing.Point(12, 220);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(640, 277);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Phần trả lời";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbChooseD);
            this.groupBox5.Controls.Add(this.rbChooseB);
            this.groupBox5.Controls.Add(this.rbChooseC);
            this.groupBox5.Controls.Add(this.rbChooseA);
            this.groupBox5.Location = new System.Drawing.Point(10, 77);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(613, 153);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Lựa chọn";
            // 
            // rbChooseD
            // 
            this.rbChooseD.AutoSize = true;
            this.rbChooseD.Location = new System.Drawing.Point(319, 99);
            this.rbChooseD.Name = "rbChooseD";
            this.rbChooseD.Size = new System.Drawing.Size(71, 17);
            this.rbChooseD.TabIndex = 3;
            this.rbChooseD.TabStop = true;
            this.rbChooseD.Text = "Đáp án D";
            this.rbChooseD.UseVisualStyleBackColor = true;
            // 
            // rbChooseB
            // 
            this.rbChooseB.AutoSize = true;
            this.rbChooseB.Location = new System.Drawing.Point(319, 38);
            this.rbChooseB.Name = "rbChooseB";
            this.rbChooseB.Size = new System.Drawing.Size(70, 17);
            this.rbChooseB.TabIndex = 2;
            this.rbChooseB.TabStop = true;
            this.rbChooseB.Text = "Đáp án B";
            this.rbChooseB.UseVisualStyleBackColor = true;
            // 
            // rbChooseC
            // 
            this.rbChooseC.AutoSize = true;
            this.rbChooseC.Location = new System.Drawing.Point(6, 99);
            this.rbChooseC.Name = "rbChooseC";
            this.rbChooseC.Size = new System.Drawing.Size(70, 17);
            this.rbChooseC.TabIndex = 1;
            this.rbChooseC.TabStop = true;
            this.rbChooseC.Text = "Đáp án C";
            this.rbChooseC.UseVisualStyleBackColor = true;
            // 
            // rbChooseA
            // 
            this.rbChooseA.AutoSize = true;
            this.rbChooseA.Location = new System.Drawing.Point(6, 38);
            this.rbChooseA.Name = "rbChooseA";
            this.rbChooseA.Size = new System.Drawing.Size(70, 17);
            this.rbChooseA.TabIndex = 0;
            this.rbChooseA.TabStop = true;
            this.rbChooseA.Text = "Đáp án A";
            this.rbChooseA.UseVisualStyleBackColor = true;
            // 
            // lbQuestion
            // 
            this.lbQuestion.AutoSize = true;
            this.lbQuestion.Location = new System.Drawing.Point(7, 16);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(43, 13);
            this.lbQuestion.TabIndex = 3;
            this.lbQuestion.Text = "Câu hỏi";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(10, 236);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Nộp bài";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnNextQuizzes
            // 
            this.btnNextQuizzes.Location = new System.Drawing.Point(524, 236);
            this.btnNextQuizzes.Name = "btnNextQuizzes";
            this.btnNextQuizzes.Size = new System.Drawing.Size(99, 23);
            this.btnNextQuizzes.TabIndex = 1;
            this.btnNextQuizzes.Text = "Câu kế tiếp";
            this.btnNextQuizzes.UseVisualStyleBackColor = true;
            this.btnNextQuizzes.Click += new System.EventHandler(this.btnNextQuizzes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 510);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbExamSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExamNumberOf;
        private System.Windows.Forms.Button btnAddExam;
        private System.Windows.Forms.TextBox txtExamTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExamTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbExam;
        private System.Windows.Forms.Button btnRegisterExam;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbChooseD;
        private System.Windows.Forms.RadioButton rbChooseB;
        private System.Windows.Forms.RadioButton rbChooseC;
        private System.Windows.Forms.RadioButton rbChooseA;
        private System.Windows.Forms.Label lbQuestion;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnNextQuizzes;
    }
}

