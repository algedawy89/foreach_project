namespace Graammar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.HeadrPanel = new System.Windows.Forms.Panel();
            this.runPanel = new System.Windows.Forms.Panel();
            this.FilePanel = new System.Windows.Forms.Panel();
            this.RunBtn = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.RichConsole = new System.Windows.Forms.RichTextBox();
            this.Bodypanel = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.RichInput = new System.Windows.Forms.RichTextBox();
            this.Errorsbox = new System.Windows.Forms.RichTextBox();
            this.HeadrPanel.SuspendLayout();
            this.runPanel.SuspendLayout();
            this.FilePanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.Bodypanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeadrPanel
            // 
            this.HeadrPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.HeadrPanel.Controls.Add(this.runPanel);
            this.HeadrPanel.Controls.Add(this.FilePanel);
            this.HeadrPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeadrPanel.Location = new System.Drawing.Point(0, 0);
            this.HeadrPanel.Name = "HeadrPanel";
            this.HeadrPanel.Size = new System.Drawing.Size(1055, 62);
            this.HeadrPanel.TabIndex = 0;
            // 
            // runPanel
            // 
            this.runPanel.Controls.Add(this.Errorsbox);
            this.runPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.runPanel.Location = new System.Drawing.Point(294, 0);
            this.runPanel.Name = "runPanel";
            this.runPanel.Size = new System.Drawing.Size(761, 62);
            this.runPanel.TabIndex = 1;
            // 
            // FilePanel
            // 
            this.FilePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.FilePanel.Controls.Add(this.RunBtn);
            this.FilePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.FilePanel.Location = new System.Drawing.Point(0, 0);
            this.FilePanel.Name = "FilePanel";
            this.FilePanel.Size = new System.Drawing.Size(294, 62);
            this.FilePanel.TabIndex = 0;
            // 
            // RunBtn
            // 
            this.RunBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RunBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RunBtn.ImageKey = "play-triangle-media-shape_icon-icons.com_59260.png";
            this.RunBtn.ImageList = this.imageList1;
            this.RunBtn.Location = new System.Drawing.Point(12, 12);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(130, 43);
            this.RunBtn.TabIndex = 0;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "play-triangle-media-shape_icon-icons.com_59260.png");
            this.imageList1.Images.SetKeyName(1, "development_developer_command_programmer_prompt_icon_259768.png");
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BottomPanel.Controls.Add(this.RichConsole);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 486);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1055, 118);
            this.BottomPanel.TabIndex = 0;
            // 
            // RichConsole
            // 
            this.RichConsole.BackColor = System.Drawing.Color.LightSlateGray;
            this.RichConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichConsole.ForeColor = System.Drawing.SystemColors.Window;
            this.RichConsole.Location = new System.Drawing.Point(0, 0);
            this.RichConsole.Name = "RichConsole";
            this.RichConsole.Size = new System.Drawing.Size(1055, 118);
            this.RichConsole.TabIndex = 0;
            this.RichConsole.Text = "";
            // 
            // Bodypanel
            // 
            this.Bodypanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Bodypanel.Controls.Add(this.richTextBox1);
            this.Bodypanel.Controls.Add(this.RichInput);
            this.Bodypanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bodypanel.Location = new System.Drawing.Point(0, 62);
            this.Bodypanel.Name = "Bodypanel";
            this.Bodypanel.Size = new System.Drawing.Size(1055, 424);
            this.Bodypanel.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 18F);
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(67, 424);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.UseWaitCursor = true;
            // 
            // RichInput
            // 
            this.RichInput.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.RichInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.RichInput.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichInput.ForeColor = System.Drawing.SystemColors.Window;
            this.RichInput.Location = new System.Drawing.Point(62, 0);
            this.RichInput.Name = "RichInput";
            this.RichInput.Size = new System.Drawing.Size(993, 424);
            this.RichInput.TabIndex = 1;
            this.RichInput.Text = "";
            this.RichInput.TextChanged += new System.EventHandler(this.RichInput_TextChanged);
            // 
            // Errorsbox
            // 
            this.Errorsbox.Dock = System.Windows.Forms.DockStyle.Right;
            this.Errorsbox.Location = new System.Drawing.Point(0, 0);
            this.Errorsbox.Name = "Errorsbox";
            this.Errorsbox.ReadOnly = true;
            this.Errorsbox.Size = new System.Drawing.Size(761, 62);
            this.Errorsbox.TabIndex = 0;
            this.Errorsbox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 604);
            this.Controls.Add(this.Bodypanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.HeadrPanel);
            this.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "customCopiler";
            this.HeadrPanel.ResumeLayout(false);
            this.runPanel.ResumeLayout(false);
            this.FilePanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.Bodypanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel HeadrPanel;
        private System.Windows.Forms.Panel runPanel;
        private System.Windows.Forms.Panel FilePanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Panel Bodypanel;
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.RichTextBox RichConsole;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.RichTextBox RichInput;
        private System.Windows.Forms.RichTextBox Errorsbox;
    }
}

