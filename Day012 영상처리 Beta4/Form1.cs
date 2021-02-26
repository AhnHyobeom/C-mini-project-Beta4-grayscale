using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Day012_영상처리_Beta4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //전역 변수
        public static byte[,] dbImage;
        public static int return_i_id;
        byte[,] inImage, outImage;
        int inH, inW, outH, outW;
        string fileName;
        Bitmap paper;//그림을 콕콕 찍을 종이
        String connStr = "Server=192.168.56.101;Uid=winuser;Pwd=4321;Database=image_db;Charset=UTF8";
        MySqlConnection conn; // 교량
        MySqlCommand cmd; // 트럭
        String sql = "";  // 물건박스
        MySqlDataReader reader; // 트럭이 가져올 끈
        int openValue; // 0 DB로 오픈 1 일반 오픈
        private void Form1_Load(object sender, EventArgs e)
        {
            //<1> 데이터베이스 연결 (교량 건설) + <2> 트럭 준비
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //<4> 데이터베이스 해제 (교량 철거)
            conn.Close();
        }
        private void dB로열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openValue = 0;
            OpenDB odb = new OpenDB();
            odb.ShowDialog();
            inW = dbImage.GetLength(0);
            inH = dbImage.GetLength(1);
            inImage = new byte[inH, inW]; // 메모리 할당
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    inImage[i, j] = dbImage[i, j];
                }
            }
            equal_image();
        }
        private void dB로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
              CREATE TABLE image (
	            i_id INT NOT NULL PRIMARY KEY,		-- 랜덤하게 생성(PK).
	            i_fname VARCHAR(50) NOT NULL,		-- 파일명
	            i_extname VARCHAR(10) NOT NULL,		-- 확장명
	            i_fsize BIGINT NOT NULL,			-- 파일 크기
	            i_width INT NOT NULL,				-- 이미지 폭
	            i_height INT NOT NULL,				-- 이미지 높이
	            i_user VARCHAR(20)					-- 이미지 업로드 유저
               );
             */
            // c:\\images\\pet_raw\\cat256_01.raw
            String i_fname = "", i_extname = "";
            long i_fsize = 0;
            int i_width = 0, i_height = 0;
            if (openValue == 1)
            {
                String[] tmp = fileName.Split('\\');
                String tmp1 = tmp[tmp.Length - 1]; // cat256_01.raw
                String[] tmp2 = tmp1.Split('.');
                i_fname = tmp2[0];   //cat256_01
                i_extname = tmp2[1]; //raw
                i_fsize = new FileInfo(fileName).Length;
                i_width = (int)Math.Sqrt(i_fsize);
                i_height = i_width;
            } else
            {
                sql = "SELECT i_fname, i_extname, i_fsize, i_width, i_height FROM image WHERE i_id = " + return_i_id; // 짐 싸기
                cmd.CommandText = sql;  // 짐을 트럭에 싣기
                reader = cmd.ExecuteReader(); // 짐을 서버에 부어넣고, 끈으로 묶어서 끈만 가져옴.
                while(reader.Read())
                {
                    i_fname = (String)reader["i_fname"];
                    i_extname = (String)reader["i_extname"];
                    i_fsize = (long)reader["i_fsize"];
                    i_width = (int)reader["i_width"];
                    i_height = (int)reader["i_height"];
                }
                reader.Close();
            }
            String i_user = "Hong";
            Random rnd = new Random();
            int i_id = rnd.Next(0, int.MaxValue);
            // 이미지 테이블(부모 테이블)에 INSERT
            sql = "INSERT INTO image(i_id, i_fname, i_extname, i_fsize, i_width, i_height, i_user) VALUES (";
            sql += i_id + ", '" + i_fname + "', '" + i_extname + "', " + i_fsize + ", ";
            sql += i_width + ", " + i_height + ", '" + i_user + "')";
            cmd = new MySqlCommand("", conn);
            cmd.CommandText = sql;  // 짐을 트럭에 싣기
            cmd.ExecuteNonQuery();
            //RAW 파일을 열어서 pixel 테이블에 INSERT
            /*CREATE TABLE pixel(
              i_id INT NOT NULL, --이미지 파일 아이디(FK)
              p_row INT NOT NULL, --행 위치
              p_col INT NOT NULL, --열 위치
              p_value TINYINT UNSIGNED NOT NULL, --픽셀값
              FOREIGN KEY(i_id) REFERENCES image(i_id)
            );*/
            int p_row, p_col, p_value;
            cmd = new MySqlCommand("", conn);
            for (int i = 0; i < i_width; i++)
            {
                for (int k = 0; k < i_height; k++)
                {
                    p_row = i;
                    p_col = k;
                    p_value = (int)outImage[i, k];
                    sql = "INSERT INTO pixel(i_id, p_row, p_col, p_value) VALUES(";
                    sql += i_id + ", " + p_row + ", " + p_col + ", " + p_value + ")";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show(fileName + "입력 완료");
        }
        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openImage();
        }
        private void 원본이미지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            equal_image();
        }
        private void 밝게어둡게ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brightImage();
        }

        private void 흑백ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bwImage();
        }

        private void 반ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reverseImage();
        }

        private void 확대ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sizeUpImage();
        }

        private void 축소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sizeDownImage();
        }

        private void 회전ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotateImage();
        }

        private void 엠보싱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            embossImage();
        }

        private void 블ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blurrImage();
        }

        private void 샤프ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sharpImage();
        }

        private void 모자이크ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            erosionImage();
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dilationImage();
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openingImage();
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closingImage();
        }

        //공통 함수부
        void openImage()
        {
            openValue = 1;
            OpenFileDialog ofd = new OpenFileDialog(); //객체 생성
            ofd.ShowDialog();
            fileName = ofd.FileName;
            BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open));
            // 파일 크기 알아내기
            long fsize = new FileInfo(fileName).Length;
            // 중요! 입력이미지의 높이, 폭 알아내기
            inH = inW = (int)Math.Sqrt(fsize);
            inImage = new byte[inH, inW]; // 메모리 할당
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    inImage[i, j] = br.ReadByte();
                }
            }
            br.Close();

            equal_image();
        }

        void displayImage()
        {
            //벽, 게시판, 종이 크기 조절
            paper = new Bitmap(outH, outW);//종이
            pictureBox1.Size = new Size(outH, outW);//캔버스
            this.Size = new Size(outH + 100, outW + 150);//벽

            Color pen;
            for (int i = 0; i < outH; i++)
            {
                for (int j = 0; j < outW; j++)
                {
                    byte data = outImage[i, j];//잉크(색상값)
                    pen = Color.FromArgb(data, data, data);//팬에 잉크 묻히기
                    paper.SetPixel(j, i, pen);//종이에 찍기
                }
            }
            pictureBox1.Image = paper;//게시판에 종이를 붙이기

            toolStripStatusLabel1.Text = outH.ToString() + " x " + outW.ToString() + " " + fileName;
        }

        //영상 처리 함수부
        void equal_image()
        {
            if (inImage == null)
                return;
            outH = inH;
            outW = inW;
            outImage = new byte[outH, outW];
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    outImage[i, j] = inImage[i, j];
                }
            }
            displayImage();
        }

        void reverseImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[outH, outW];
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    outImage[i, j] = (byte)(255 - inImage[i, j]);
                }
            }
            displayImage();
        }


        void bwImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[outH, outW];
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    if (inImage[i, k] > 127)
                    {
                        outImage[i, k] = 255;
                    }
                    else
                    {
                        outImage[i, k] = 0;
                    }
                }
            }
            displayImage();
        }

        double getValue()
        {
            subform sub = new subform();//서브폼 준비
            if (sub.ShowDialog() == DialogResult.Cancel)
            {
                return 0.0;
            }
            double value = (double)sub.numUp_value.Value;
            return value;
        }

        void brightImage()
        {
            if (inImage == null)
            {
                return;
            }
            int value = (int)getValue();
            outH = inH;
            outW = inW;
            outImage = new byte[outH, outW];
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    if (inImage[i, j] + value > 255)
                    {
                        outImage[i, j] = 255;
                    }
                    else if (inImage[i, j] + value < 0)
                    {
                        outImage[i, j] = 0;
                    }
                    else
                    {
                        outImage[i, j] = (byte)(inImage[i, j] + value);
                    }
                }
            }
            displayImage();
        }

        void sizeUpImage()
        {//확대 알고리즘
            if (inImage == null)
            {
                return;
            }
            int mul = (int)getValue();
            outH = inH * mul;
            outW = inW * mul;
            outImage = new byte[outH, outW];
            for (int i = 0; i < outH; i++)
            {
                for (int j = 0; j < outW; j++)
                {
                    outImage[i, j] = inImage[i / mul, j / mul];
                }
            }
            displayImage();
        }
        void sizeDownImage()
        {//축소 알고리즘
            if (inImage == null)
            {
                return;
            }
            int div;
            div = (int)getValue();
            outH = inH / div;
            outW = inW / div;
            outImage = new byte[outH, outW];
            int sum;
            for (int i = 0; i < outH; i++)
            {//평균값으로 계산
                for (int j = 0; j < outW; j++)
                {
                    sum = 0;
                    for (int k = 0; k < div; k++)
                    {
                        for (int m = 0; m < div; m++)
                        {
                            sum = sum + inImage[i * div + k, j * div + m];
                        }
                    }
                    outImage[i, j] = (byte)(sum / (double)(div * div));
                }
            }
            displayImage();
        }

        void rotateImage()
        {//회전 알고리즘
            if (inImage == null)
            {
                return;
            }
            int degree = (int)getValue();
            outH = inH;
            outW = inW;
            outImage = new byte[outH, outW];
            calculRotate(degree);//회전 계산
            displayImage();
        }


        void calculRotate(int degree)
        {//회전 계산 알고리즘
            int center_w = inW / 2;//중심축 계산
            int center_h = inH / 2;
            int new_w;
            int new_h;
            double pi = 3.141592;
            // -degree 반시계 방향 회전
            // degree 시계 방향 회전
            double seta = pi / (180.0 / degree);
            //회전 알고리즘
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    new_w = (int)((i - center_h) * Math.Sin(seta) + (j - center_w) * Math.Cos(seta) + center_w);
                    new_h = (int)((i - center_h) * Math.Cos(seta) - (j - center_w) * Math.Sin(seta) + center_h);
                    if (new_w < 0) continue;
                    if (new_w >= inW) continue;
                    if (new_h < 0) continue;
                    if (new_h >= inH) continue;
                    outImage[i, j] = inImage[new_h, new_w];
                }
            }
            //회전 보간법 알고리즘 (hole 채우기)
            int left_pixval = 0;
            int right_pixval = 0;
            for (int i = 0; i < outH; i++)
            {
                for (int j = 0; j < outW; j++)
                {
                    if (j == 0)
                    {
                        right_pixval = outImage[i, j + 1];
                        left_pixval = right_pixval;
                    }
                    else if (j == outW - 1)
                    {
                        left_pixval = outImage[i, j - 1];
                        right_pixval = left_pixval;
                    }
                    else
                    {
                        left_pixval = outImage[i, j - 1];
                        right_pixval = outImage[i, j + 1];
                    }
                    if (outImage[i, j] == 0 && left_pixval != 0 && right_pixval != 0)
                    {
                        outImage[i, j] = (byte)((left_pixval + right_pixval) / 2);
                    }
                }
            }
        }

        void embossImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[outH, outW];
            //화소 영역 처리
            //마스크 결정
            const int MSIZE = 3;
            double[,] mask = {
                { -1.0, 0.0, 0.0},
                { 0.0, 0.0, 0.0},
                { 0.0, 0.0, 1.0} };
            //임시 입력 출력 메모리 할당
            double[,] tmpInput = new double[inH + 2, inW + 2];
            double[,] tmpOutput = new double[outH, outW];

            //임시 입력을 중간값인 127로 초기화 -> 평균 값으로 하거나 가장자리 값을 땡겨온다
            for (int i = 0; i < inH + 2; i++)
            {
                for (int j = 0; j < inW + 2; j++)
                {
                    tmpInput[i, j] = 127;
                }
            }
            //입력 -> 임시 입력
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    tmpInput[i + 1, j + 1] = inImage[i, j];
                }
            }
            double sum = 0.0;
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    for (int k = 0; k < MSIZE; k++)
                    {
                        for (int m = 0; m < MSIZE; m++)
                        {
                            sum += tmpInput[i + k, j + m] * mask[k, m];
                        }
                    }
                    tmpOutput[i, j] = sum;
                    sum = 0.0;
                }
            }

            //후처리 Mask의 합이 0이면 127 더하기
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    tmpOutput[i, j] += 127;
                }
            }
            //임시 출력 -> 원래 출력
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    double d = tmpOutput[i, j];
                    if (d > 255.0)
                    {
                        d = 255.0;
                    }
                    else if (d < 0.0)
                    {
                        d = 00;
                    }
                    else
                    {
                        outImage[i, j] = (byte)d;
                    }
                }
            }
            displayImage();
        }

        void blurrImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[outH, outW];
            //화소 영역 처리
            //마스크 결정
            const int MSIZE = 3;
            double[,] mask = {
                { 1/9.0, 1/9.0, 1/9.0},
                { 1/9.0, 1/9.0, 1/9.0},
                { 1/9.0, 1/9.0, 1/9.0} };
            //임시 입력 출력 메모리 할당
            double[,] tmpInput = new double[inH + 2, inW + 2];
            double[,] tmpOutput = new double[outH, outW];

            //임시 입력을 중간값인 127로 초기화 -> 평균 값으로 하거나 가장자리 값을 땡겨온다
            for (int i = 0; i < inH + 2; i++)
            {
                for (int j = 0; j < inW + 2; j++)
                {
                    tmpInput[i, j] = 127;
                }
            }
            //입력 -> 임시 입력
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    tmpInput[i + 1, j + 1] = inImage[i, j];
                }
            }
            double sum = 0.0;
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    for (int k = 0; k < MSIZE; k++)
                    {
                        for (int m = 0; m < MSIZE; m++)
                        {
                            sum += tmpInput[i + k, j + m] * mask[k, m];
                        }
                    }
                    tmpOutput[i, j] = sum;
                    sum = 0.0;
                }
            }

            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    double d = tmpOutput[i, j];
                    if (d > 255.0)
                    {
                        d = 255.0;
                    }
                    else if (d < 0.0)
                    {
                        d = 00;
                    }
                    else
                    {
                        outImage[i, j] = (byte)d;
                    }
                }
            }
            displayImage();
        }

        void sharpImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[outH, outW];
            //화소 영역 처리
            //마스크 결정
            const int MSIZE = 3;
            double[,] mask = {
                { -1, -1, -1},
                { -1, 9, -1},
                { -1, -1, -1} };
            //임시 입력 출력 메모리 할당
            double[,] tmpInput = new double[inH + 2, inW + 2];
            double[,] tmpOutput = new double[outH, outW];

            //임시 입력을 중간값인 127로 초기화 -> 평균 값으로 하거나 가장자리 값을 땡겨온다
            for (int i = 0; i < inH + 2; i++)
            {
                for (int j = 0; j < inW + 2; j++)
                {
                    tmpInput[i, j] = 127;
                }
            }
            //입력 -> 임시 입력
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    tmpInput[i + 1, j + 1] = inImage[i, j];
                }
            }
            double sum = 0.0;
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    for (int k = 0; k < MSIZE; k++)
                    {
                        for (int m = 0; m < MSIZE; m++)
                        {
                            sum += tmpInput[i + k, j + m] * mask[k, m];
                        }
                    }
                    tmpOutput[i, j] = sum;
                    sum = 0.0;
                }
            }

            //후처리 Mask의 합이 0이면 127 더하기
            /* for (int i = 0; i < inH; i++)
             {
                 for (int j = 0; j < inW; j++)
                 {
                     tmpOutput[i, j] += 127;
                 }
             }*/
            //임시 출력 -> 원래 출력
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    double d = tmpOutput[i, j];
                    if (d > 255.0)
                    {
                        d = 255.0;
                    }
                    else if (d < 0.0)
                    {
                        d = 00;
                    }
                    else
                    {
                        outImage[i, j] = (byte)d;
                    }
                }
            }
            displayImage();
        }

        void erosionImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[outH, outW];
            //화소 영역 처리
            //마스크 결정
            calculErosion();
            displayImage();
        }

        void calculErosion()
        {
            int[,] erosionMask = { //마스크 설정
                    { 0, 0, 1, 0, 0},
                    { 1, 1, 1, 1, 1},
                    { 1, 1, 1, 1, 1},
                    { 1, 1, 1, 1, 1},
                    { 0, 0, 1, 0, 0} };
            byte isErosion;
            for (int i = 2; i < inH - 2; i++)
            {//가장자리는 처리하지 않음
                for (int j = 2; j < inW - 2; j++)
                {
                    isErosion = 255;
                    for (int k = 0; k < 5; k++)
                    {
                        for (int m = 0; m < 5; m++)
                        {
                            if (erosionMask[k, m] == 1)
                            {
                                if (inImage[i - 2 + k, j - 2 + m] == 0)
                                {//이미지가 0이라면
                                    isErosion = 0;//침식
                                    outImage[i, j] = isErosion;
                                    break;
                                }
                            }
                        }
                        if (isErosion == 0)
                        {
                            break;
                        }
                    }
                    if (isErosion == 255)
                    {//마스크를 모두 통과했다면
                        outImage[i, j] = isErosion;
                    }
                }
            }
        }
        void dilationImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[outH, outW];
            //화소 영역 처리
            //마스크 결정
            calculDilation();
            displayImage();
        }
        void calculDilation()
        {
            int[,] dilationMask = { //마스크 설정
                    { 0, 0, 1, 0, 0},
                    { 1, 1, 1, 1, 1},
                    { 1, 1, 1, 1, 1},
                    { 1, 1, 1, 1, 1},
                    { 0, 0, 1, 0, 0} };
            byte isDilation;
            for (int i = 2; i < inH - 2; i++)
            {//가장자리는 처리하지 않음
                for (int j = 2; j < inW - 2; j++)
                {
                    isDilation = 0;
                    for (int k = 0; k < 5; k++)
                    {
                        for (int m = 0; m < 5; m++)
                        {
                            if (dilationMask[k, m] == 1)
                            {
                                if (inImage[i - 2 + k, j - 2 + m] == 255)
                                {//이미지가 255라면
                                    isDilation = 255;//팽창
                                    outImage[i, j] = isDilation;
                                    break;
                                }
                            }
                        }
                        if (isDilation == 255)
                        {
                            break;
                        }
                    }
                    if (isDilation == 0)
                    {//마스크를 모두 통과했다면
                        outImage[i, j] = isDilation;
                    }
                }
            }
        }

        void openingImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[outH, outW];
            //화소 영역 처리
            //마스크 결정
            calculErosion();
            //임시 출력 메모리 생성
            byte[,] outBufImage = new byte[outH, outW];
            int[,] dilationMask = { //마스크 설정
                { 0, 1, 0},
                { 1, 1, 1},
                { 0, 1, 0} };
            byte isDilation;
            for (int i = 1; i < inH - 1; i++)
            {//엣지는 처리하지 않음
                for (int j = 1; j < inW - 1; j++)
                {
                    isDilation = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        for (int m = 0; m < 3; m++)
                        {
                            if (dilationMask[k, m] == 1)
                            {//mask 값이 1이고
                                if (outImage[i - 1 + k, j - 1 + m] == 255)
                                {//이미지가 255라면
                                    isDilation = 255;//팽창
                                    outBufImage[i, j] = isDilation;
                                    break;
                                }
                            }
                        }
                        if (isDilation == 255)
                        {
                            break;
                        }
                    }
                    if (isDilation == 0)
                    {//마스크를 모두 통과했다면
                        outBufImage[i, j] = isDilation;
                    }
                }
            }
            //임시 출력 -> 출력
            for (int i = 0; i < outH; i++)
            {
                for (int j = 0; j < outW; j++)
                {
                    outImage[i, j] = outBufImage[i, j];
                }
            }
            displayImage();
        }

        void closingImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[outH, outW];
            //화소 영역 처리
            //마스크 결정
            calculDilation();
            //임시 출력 메모리 생성
            byte[,] outBufImage = new byte[outH, outW];
            int[,] erosionMask = { //마스크 설정
                { 0, 1, 0},
                { 1, 1, 1},
                { 0, 1, 0} };
            byte isErosion;
            for (int i = 1; i < inH - 1; i++)
            {//가장자리는 처리하지 않음
                for (int j = 1; j < inW - 1; j++)
                {
                    isErosion = 255;
                    for (int k = 0; k < 3; k++)
                    {
                        for (int m = 0; m < 3; m++)
                        {
                            if (erosionMask[k, m] == 1)
                            {
                                if (outImage[i - 1 + k, j - 1 + m] == 0)
                                {//이미지가 0이라면
                                    isErosion = 0;//침식
                                    outBufImage[i, j] = isErosion;
                                    break;
                                }
                            }
                        }
                        if (isErosion == 0)
                        {
                            break;
                        }
                    }
                    if (isErosion == 255)
                    {//마스크를 모두 통과했다면
                        outBufImage[i, j] = isErosion;
                    }
                }
            }
            //임시 출력 -> 출력
            for (int i = 0; i < outH; i++)
            {
                for (int j = 0; j < outW; j++)
                {
                    outImage[i, j] = outBufImage[i, j];
                }
            }
            displayImage();
        }
    }
}
