namespace Mandelbrot_2
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
            this.pbGraph = new System.Windows.Forms.PictureBox();
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtZoomFactor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCalcArea = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGraph
            // 
            this.pbGraph.Location = new System.Drawing.Point(12, 12);
            this.pbGraph.MaximumSize = new System.Drawing.Size(800, 800);
            this.pbGraph.MinimumSize = new System.Drawing.Size(800, 800);
            this.pbGraph.Name = "pbGraph";
            this.pbGraph.Size = new System.Drawing.Size(800, 800);
            this.pbGraph.TabIndex = 0;
            this.pbGraph.TabStop = false;
            this.pbGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGraph_Paint);
            this.pbGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbGraph_MouseClick);
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(12, 837);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(131, 20);
            this.txtN.TabIndex = 2;
            this.txtN.Text = "1000";
            // 
            // txtZoomFactor
            // 
            this.txtZoomFactor.Location = new System.Drawing.Point(149, 837);
            this.txtZoomFactor.Name = "txtZoomFactor";
            this.txtZoomFactor.Size = new System.Drawing.Size(131, 20);
            this.txtZoomFactor.TabIndex = 3;
            this.txtZoomFactor.Text = "2,5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 816);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 816);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Zoom factor";
            // 
            // txtCalcArea
            // 
            this.txtCalcArea.Location = new System.Drawing.Point(447, 832);
            this.txtCalcArea.Name = "txtCalcArea";
            this.txtCalcArea.Size = new System.Drawing.Size(137, 20);
            this.txtCalcArea.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 871);
            this.Controls.Add(this.txtCalcArea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtZoomFactor);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.pbGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGraph;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.TextBox txtZoomFactor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCalcArea;
    }
}

