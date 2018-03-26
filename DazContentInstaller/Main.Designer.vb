<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.btn_install = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.runtimes_txt = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_moveOnInstall = New System.Windows.Forms.CheckBox()
        Me.lbl_success = New System.Windows.Forms.Label()
        Me.lbl_fail = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_install
        '
        Me.btn_install.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_install.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_install.Location = New System.Drawing.Point(288, 161)
        Me.btn_install.Name = "btn_install"
        Me.btn_install.Size = New System.Drawing.Size(182, 54)
        Me.btn_install.TabIndex = 0
        Me.btn_install.Text = "Run Installer"
        Me.btn_install.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(482, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'runtimes_txt
        '
        Me.runtimes_txt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.runtimes_txt.FormattingEnabled = True
        Me.runtimes_txt.Items.AddRange(New Object() {"Runtime 1", "Runtime 2", "C:\Users\Collin\Documents\GitHub\DazContentInstaller\DazContentInstaller", "Runtime 3", "Runtime 4", "Line 6"})
        Me.runtimes_txt.Location = New System.Drawing.Point(12, 57)
        Me.runtimes_txt.Name = "runtimes_txt"
        Me.runtimes_txt.Size = New System.Drawing.Size(458, 95)
        Me.runtimes_txt.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Runtime To Install To:"
        '
        'cb_moveOnInstall
        '
        Me.cb_moveOnInstall.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cb_moveOnInstall.AutoSize = True
        Me.cb_moveOnInstall.Checked = True
        Me.cb_moveOnInstall.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_moveOnInstall.Location = New System.Drawing.Point(12, 161)
        Me.cb_moveOnInstall.Name = "cb_moveOnInstall"
        Me.cb_moveOnInstall.Size = New System.Drawing.Size(139, 17)
        Me.cb_moveOnInstall.TabIndex = 4
        Me.cb_moveOnInstall.Text = "Move Archive On Install"
        Me.cb_moveOnInstall.UseVisualStyleBackColor = True
        '
        'lbl_success
        '
        Me.lbl_success.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_success.AutoSize = True
        Me.lbl_success.Location = New System.Drawing.Point(9, 185)
        Me.lbl_success.Name = "lbl_success"
        Me.lbl_success.Size = New System.Drawing.Size(57, 13)
        Me.lbl_success.TabIndex = 5
        Me.lbl_success.Text = "Success:0"
        '
        'lbl_fail
        '
        Me.lbl_fail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_fail.AutoSize = True
        Me.lbl_fail.Location = New System.Drawing.Point(9, 201)
        Me.lbl_fail.Name = "lbl_fail"
        Me.lbl_fail.Size = New System.Drawing.Size(52, 13)
        Me.lbl_fail.TabIndex = 6
        Me.lbl_fail.Text = "Failures:0"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 226)
        Me.Controls.Add(Me.lbl_fail)
        Me.Controls.Add(Me.lbl_success)
        Me.Controls.Add(Me.cb_moveOnInstall)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.runtimes_txt)
        Me.Controls.Add(Me.btn_install)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main"
        Me.Text = "Daz Archive Installer | Version 1.0.0"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_install As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents runtimes_txt As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cb_moveOnInstall As CheckBox
    Friend WithEvents lbl_success As Label
    Friend WithEvents lbl_fail As Label
End Class
