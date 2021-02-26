
namespace Day012_영상처리_Beta4
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.화소점처리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.원본이미지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.밝게어둡게ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.흑백ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.반ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.기하학처리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.확대ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.축소ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회전ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.영역처리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.엠보싱ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.블ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.샤프ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모자이크ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모폴로지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dB로열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dB로저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 62);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 160);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 349);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this.statusStrip1.Size = new System.Drawing.Size(640, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(152, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.화소점처리ToolStripMenuItem,
            this.기하학처리ToolStripMenuItem,
            this.영역처리ToolStripMenuItem,
            this.모폴로지ToolStripMenuItem,
            this.dBToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(640, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.저장ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.열기ToolStripMenuItem.Text = "열기";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.저장ToolStripMenuItem.Text = "저장";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.종료ToolStripMenuItem.Text = "종료";
            // 
            // 화소점처리ToolStripMenuItem
            // 
            this.화소점처리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.원본이미지ToolStripMenuItem,
            this.밝게어둡게ToolStripMenuItem,
            this.흑백ToolStripMenuItem,
            this.반ToolStripMenuItem});
            this.화소점처리ToolStripMenuItem.Name = "화소점처리ToolStripMenuItem";
            this.화소점처리ToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.화소점처리ToolStripMenuItem.Text = "화소점 처리";
            // 
            // 원본이미지ToolStripMenuItem
            // 
            this.원본이미지ToolStripMenuItem.Name = "원본이미지ToolStripMenuItem";
            this.원본이미지ToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.원본이미지ToolStripMenuItem.Text = "원본 이미지";
            this.원본이미지ToolStripMenuItem.Click += new System.EventHandler(this.원본이미지ToolStripMenuItem_Click);
            // 
            // 밝게어둡게ToolStripMenuItem
            // 
            this.밝게어둡게ToolStripMenuItem.Name = "밝게어둡게ToolStripMenuItem";
            this.밝게어둡게ToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.밝게어둡게ToolStripMenuItem.Text = "밝게 / 어둡게";
            this.밝게어둡게ToolStripMenuItem.Click += new System.EventHandler(this.밝게어둡게ToolStripMenuItem_Click);
            // 
            // 흑백ToolStripMenuItem
            // 
            this.흑백ToolStripMenuItem.Name = "흑백ToolStripMenuItem";
            this.흑백ToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.흑백ToolStripMenuItem.Text = "흑백";
            this.흑백ToolStripMenuItem.Click += new System.EventHandler(this.흑백ToolStripMenuItem_Click);
            // 
            // 반ToolStripMenuItem
            // 
            this.반ToolStripMenuItem.Name = "반ToolStripMenuItem";
            this.반ToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.반ToolStripMenuItem.Text = "반전";
            this.반ToolStripMenuItem.Click += new System.EventHandler(this.반ToolStripMenuItem_Click);
            // 
            // 기하학처리ToolStripMenuItem
            // 
            this.기하학처리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.확대ToolStripMenuItem,
            this.축소ToolStripMenuItem,
            this.회전ToolStripMenuItem});
            this.기하학처리ToolStripMenuItem.Name = "기하학처리ToolStripMenuItem";
            this.기하학처리ToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.기하학처리ToolStripMenuItem.Text = "기하학 처리";
            // 
            // 확대ToolStripMenuItem
            // 
            this.확대ToolStripMenuItem.Name = "확대ToolStripMenuItem";
            this.확대ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.확대ToolStripMenuItem.Text = "확대";
            this.확대ToolStripMenuItem.Click += new System.EventHandler(this.확대ToolStripMenuItem_Click);
            // 
            // 축소ToolStripMenuItem
            // 
            this.축소ToolStripMenuItem.Name = "축소ToolStripMenuItem";
            this.축소ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.축소ToolStripMenuItem.Text = "축소";
            this.축소ToolStripMenuItem.Click += new System.EventHandler(this.축소ToolStripMenuItem_Click);
            // 
            // 회전ToolStripMenuItem
            // 
            this.회전ToolStripMenuItem.Name = "회전ToolStripMenuItem";
            this.회전ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.회전ToolStripMenuItem.Text = "회전";
            this.회전ToolStripMenuItem.Click += new System.EventHandler(this.회전ToolStripMenuItem_Click);
            // 
            // 영역처리ToolStripMenuItem
            // 
            this.영역처리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.엠보싱ToolStripMenuItem,
            this.블ToolStripMenuItem,
            this.샤프ToolStripMenuItem,
            this.모자이크ToolStripMenuItem});
            this.영역처리ToolStripMenuItem.Name = "영역처리ToolStripMenuItem";
            this.영역처리ToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.영역처리ToolStripMenuItem.Text = "영역 처리";
            // 
            // 엠보싱ToolStripMenuItem
            // 
            this.엠보싱ToolStripMenuItem.Name = "엠보싱ToolStripMenuItem";
            this.엠보싱ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.엠보싱ToolStripMenuItem.Text = "엠보싱";
            this.엠보싱ToolStripMenuItem.Click += new System.EventHandler(this.엠보싱ToolStripMenuItem_Click);
            // 
            // 블ToolStripMenuItem
            // 
            this.블ToolStripMenuItem.Name = "블ToolStripMenuItem";
            this.블ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.블ToolStripMenuItem.Text = "블러링";
            this.블ToolStripMenuItem.Click += new System.EventHandler(this.블ToolStripMenuItem_Click);
            // 
            // 샤프ToolStripMenuItem
            // 
            this.샤프ToolStripMenuItem.Name = "샤프ToolStripMenuItem";
            this.샤프ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.샤프ToolStripMenuItem.Text = "샤프닝";
            this.샤프ToolStripMenuItem.Click += new System.EventHandler(this.샤프ToolStripMenuItem_Click);
            // 
            // 모자이크ToolStripMenuItem
            // 
            this.모자이크ToolStripMenuItem.Name = "모자이크ToolStripMenuItem";
            this.모자이크ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.모자이크ToolStripMenuItem.Text = "모자이크";
            this.모자이크ToolStripMenuItem.Click += new System.EventHandler(this.모자이크ToolStripMenuItem_Click);
            // 
            // 모폴로지ToolStripMenuItem
            // 
            this.모폴로지ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erosionToolStripMenuItem,
            this.dilationToolStripMenuItem,
            this.openingToolStripMenuItem,
            this.closingToolStripMenuItem});
            this.모폴로지ToolStripMenuItem.Name = "모폴로지ToolStripMenuItem";
            this.모폴로지ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.모폴로지ToolStripMenuItem.Text = "모폴로지";
            // 
            // erosionToolStripMenuItem
            // 
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.erosionToolStripMenuItem.Text = "Erosion";
            this.erosionToolStripMenuItem.Click += new System.EventHandler(this.erosionToolStripMenuItem_Click);
            // 
            // dilationToolStripMenuItem
            // 
            this.dilationToolStripMenuItem.Name = "dilationToolStripMenuItem";
            this.dilationToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.dilationToolStripMenuItem.Text = "Dilation";
            this.dilationToolStripMenuItem.Click += new System.EventHandler(this.dilationToolStripMenuItem_Click);
            // 
            // openingToolStripMenuItem
            // 
            this.openingToolStripMenuItem.Name = "openingToolStripMenuItem";
            this.openingToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.openingToolStripMenuItem.Text = "Opening";
            this.openingToolStripMenuItem.Click += new System.EventHandler(this.openingToolStripMenuItem_Click);
            // 
            // closingToolStripMenuItem
            // 
            this.closingToolStripMenuItem.Name = "closingToolStripMenuItem";
            this.closingToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.closingToolStripMenuItem.Text = "Closing";
            this.closingToolStripMenuItem.Click += new System.EventHandler(this.closingToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dBToolStripMenuItem
            // 
            this.dBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dB로열기ToolStripMenuItem,
            this.dB로저장ToolStripMenuItem});
            this.dBToolStripMenuItem.Name = "dBToolStripMenuItem";
            this.dBToolStripMenuItem.Size = new System.Drawing.Size(43, 24);
            this.dBToolStripMenuItem.Text = "DB";
            // 
            // dB로열기ToolStripMenuItem
            // 
            this.dB로열기ToolStripMenuItem.Name = "dB로열기ToolStripMenuItem";
            this.dB로열기ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dB로열기ToolStripMenuItem.Text = "DB로 열기";
            this.dB로열기ToolStripMenuItem.Click += new System.EventHandler(this.dB로열기ToolStripMenuItem_Click);
            // 
            // dB로저장ToolStripMenuItem
            // 
            this.dB로저장ToolStripMenuItem.Name = "dB로저장ToolStripMenuItem";
            this.dB로저장ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dB로저장ToolStripMenuItem.Text = "DB로 저장";
            this.dB로저장ToolStripMenuItem.Click += new System.EventHandler(this.dB로저장ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 375);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "영상처리 Beta4";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 화소점처리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 원본이미지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 밝게어둡게ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 흑백ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 반ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 기하학처리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 확대ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 축소ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 회전ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 영역처리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 엠보싱ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 블ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 샤프ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 모자이크ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 모폴로지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dB로열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dB로저장ToolStripMenuItem;
    }
}

