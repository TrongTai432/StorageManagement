
namespace QLKho
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HangHoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PhieuNKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PhieuXKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NhaCungCapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Wheat;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.trợGiúpToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1413, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.BackColor = System.Drawing.Color.Tan;
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đổiMậtKhẩuToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.hệThốngToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            this.hệThốngToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.hệThốngToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.BackColor = System.Drawing.Color.Tan;
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.BackColor = System.Drawing.Color.Tan;
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.BackColor = System.Drawing.Color.Tan;
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HangHoaToolStripMenuItem,
            this.PhieuNKToolStripMenuItem,
            this.PhieuXKToolStripMenuItem,
            this.NhaCungCapToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // HangHoaToolStripMenuItem
            // 
            this.HangHoaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.HangHoaToolStripMenuItem.Name = "HangHoaToolStripMenuItem";
            this.HangHoaToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.HangHoaToolStripMenuItem.Text = "Hàng Hóa";
            this.HangHoaToolStripMenuItem.Click += new System.EventHandler(this.HangHoaToolStripMenuItem_Click_1);
            // 
            // PhieuNKToolStripMenuItem
            // 
            this.PhieuNKToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.PhieuNKToolStripMenuItem.Name = "PhieuNKToolStripMenuItem";
            this.PhieuNKToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.PhieuNKToolStripMenuItem.Text = "Phiếu Nhập Kho";
            this.PhieuNKToolStripMenuItem.Click += new System.EventHandler(this.PhieuNKToolStripMenuItem_Click);
            // 
            // PhieuXKToolStripMenuItem
            // 
            this.PhieuXKToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.PhieuXKToolStripMenuItem.Name = "PhieuXKToolStripMenuItem";
            this.PhieuXKToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.PhieuXKToolStripMenuItem.Text = "Phiếu Xuất Kho";
            this.PhieuXKToolStripMenuItem.Click += new System.EventHandler(this.PhieuXKToolStripMenuItem_Click);
            // 
            // NhaCungCapToolStripMenuItem
            // 
            this.NhaCungCapToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.NhaCungCapToolStripMenuItem.Name = "NhaCungCapToolStripMenuItem";
            this.NhaCungCapToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.NhaCungCapToolStripMenuItem.Text = "Nhà cung cấp";
            this.NhaCungCapToolStripMenuItem.Click += new System.EventHandler(this.NhaCungCapToolStripMenuItem_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.BackColor = System.Drawing.Color.Tan;
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLKho.Properties.Resources.almacen_ilustracion_lifeder_1024x614;
            this.ClientSize = new System.Drawing.Size(1413, 792);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ KHO";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HangHoaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PhieuNKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PhieuXKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NhaCungCapToolStripMenuItem;
    }
}

