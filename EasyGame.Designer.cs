namespace EasyGamePractice
{
    partial class EasyGame
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
            this.components = new System.ComponentModel.Container();
            this.PBShow = new System.Windows.Forms.PictureBox();
            this.RandomNum = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PBShow)).BeginInit();
            this.SuspendLayout();
            // 
            // PBShow
            // 
            this.PBShow.Location = new System.Drawing.Point(30, 30);
            this.PBShow.Name = "PBShow";
            this.PBShow.Size = new System.Drawing.Size(180, 180);
            this.PBShow.TabIndex = 0;
            this.PBShow.TabStop = false;
            this.PBShow.Paint += new System.Windows.Forms.PaintEventHandler(this.PBShow_Paint);
            // 
            // RandomNum
            // 
            this.RandomNum.AutoSize = true;
            this.RandomNum.Location = new System.Drawing.Point(77, 11);
            this.RandomNum.Name = "RandomNum";
            this.RandomNum.Size = new System.Drawing.Size(35, 13);
            this.RandomNum.TabIndex = 1;
            this.RandomNum.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // EasyGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 392);
            this.Controls.Add(this.RandomNum);
            this.Controls.Add(this.PBShow);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "EasyGame";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PBShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBShow;
        private System.Windows.Forms.Label RandomNum;
        private System.Windows.Forms.Timer timer1;
    }
}

