using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.Access
{
    public class UnitType
    {
        public static bool UnitTypeAdd(Model.T_BASE_UNITTYPEModel model)
        {
            Access.FactoryT_BASE_UNITTYPEAccess af = new Access.FactoryT_BASE_UNITTYPEAccess();
            int ret = af.Add(model);
            return ret > 0;
        }

        public static bool UnitTypeEdit(Model.T_BASE_UNITTYPEModel model)
        {
            Access.FactoryT_BASE_UNITTYPEAccess af = new Access.FactoryT_BASE_UNITTYPEAccess();
            int ret = af.Modify(model);
            return ret > 0;
        }

        public static bool UnitTypeDel(string id) {
            Model.T_BASE_UNITTYPEModel model = GetUnitTypeModel(id);
            model.SFSC = 1;
            return UnitTypeEdit(model);
        }


        public static Model.T_BASE_UNITTYPEModel GetUnitTypeModel(string id)
        {
            Access.FactoryT_BASE_UNITTYPEAccess af = new Access.FactoryT_BASE_UNITTYPEAccess();
            return af.Query(id);
        }

        public static List<Model.T_BASE_UNITTYPEModel> GetUnitTypeList()
        {
            Access.FactoryT_BASE_UNITTYPEAccess af = new Access.FactoryT_BASE_UNITTYPEAccess();
            return af.QueryList("T.SFSC=0","TO_NUMBER(T.BL1)");
        }
    }
}
