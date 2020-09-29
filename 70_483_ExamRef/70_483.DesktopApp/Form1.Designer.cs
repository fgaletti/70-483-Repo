namespace _70_483.DesktopApp
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.debugInstructionsLabel = new System.Windows.Forms.Label();
            this.helloWorldLabel = new System.Windows.Forms.Label();
            this.btnStartAverage = new System.Windows.Forms.Button();
            this.txtRandom = new System.Windows.Forms.TextBox();
            this.lblAverage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(191, 351);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(418, 20);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click here to continue learning how to build a desktop app!";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // debugInstructionsLabel
            // 
            this.debugInstructionsLabel.AutoSize = true;
            this.debugInstructionsLabel.Location = new System.Drawing.Point(146, 107);
            this.debugInstructionsLabel.Name = "debugInstructionsLabel";
            this.debugInstructionsLabel.Size = new System.Drawing.Size(0, 20);
            this.debugInstructionsLabel.TabIndex = 1;
            // 
            // helloWorldLabel
            // 
            this.helloWorldLabel.AutoSize = true;
            this.helloWorldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloWorldLabel.Location = new System.Drawing.Point(303, 30);
            this.helloWorldLabel.Name = "helloWorldLabel";
            this.helloWorldLabel.Size = new System.Drawing.Size(250, 37);
            this.helloWorldLabel.TabIndex = 3;
            this.helloWorldLabel.Text = "Random Access";
            // 
            // btnStartAverage
            // 
            this.btnStartAverage.Location = new System.Drawing.Point(40, 150);
            this.btnStartAverage.Name = "btnStartAverage";
            this.btnStartAverage.Size = new System.Drawing.Size(180, 63);
            this.btnStartAverage.TabIndex = 4;
            this.btnStartAverage.Text = "Start Average";
            this.btnStartAverage.UseVisualStyleBackColor = true;
            this.btnStartAverage.Click += new System.EventHandler(this.btnStartAverage_Click);
            // 
            // txtRandom
            // 
            this.txtRandom.Location = new System.Drawing.Point(40, 101);
            this.txtRandom.Name = "txtRandom";
            this.txtRandom.Size = new System.Drawing.Size(293, 26);
            this.txtRandom.TabIndex = 5;
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(36, 237);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(51, 20);
            this.lblAverage.TabIndex = 6;
            this.lblAverage.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.txtRandom);
            this.Controls.Add(this.btnStartAverage);
            this.Controls.Add(this.helloWorldLabel);
            this.Controls.Add(this.debugInstructionsLabel);
            this.Controls.Add(this.linkLabel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label debugInstructionsLabel;
        private System.Windows.Forms.Label helloWorldLabel;
        private System.Windows.Forms.Button btnStartAverage;
        private System.Windows.Forms.TextBox txtRandom;
        private System.Windows.Forms.Label lblAverage;
    }
}

