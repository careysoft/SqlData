using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace Careysoft.Dotnet.Tools.SqlData.AExecuteSvc
{
    [RunInstaller(true)]
    public partial class InstallerExecuteSvc : System.Configuration.Install.Installer
    {
        public InstallerExecuteSvc()
        {
            InitializeComponent();
        }
    }
}
