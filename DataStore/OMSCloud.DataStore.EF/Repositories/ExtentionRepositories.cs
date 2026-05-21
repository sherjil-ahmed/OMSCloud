using OMSCloud.DataStore.EF.OMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OMSCloud.DataStore.EF.Repositories
{
    public static class ExtentionRepositories
    {
        //public static void UpdateProductCategory(this ProductRepository repo, Product product)
        //{
        //    ProductAttributePairRepository paRepo = new ProductAttributePairRepository(repo.OMSContext);

        //    var catAttribs = (from ca in repo.OMSContext.CategoryAttributePair
        //                      where ca.CategoryID == product.CategoryID
        //                      select ca.AttributeID).ToList();

        //    var proAtrribs = (from pa in repo.OMSContext.ProductAttributePair
        //                      where pa.ProductID == product.ProductID
        //                      select pa).ToList();

        //    List<int> commonAttrib = new List<int>();
        //    foreach (var proAttrib in proAtrribs)
        //    {
        //        if (!catAttribs.Contains(proAttrib.AttributeID))
        //            paRepo.Delete(proAttrib);
        //        else
        //            commonAttrib.Add(proAttrib.AttributeID);
        //    }

        //    foreach (var AttributeID in catAttribs)
        //    {
        //        if (!commonAttrib.Contains(AttributeID))
        //        {
        //            ProductAttributePair pap = new ProductAttributePair();
        //            pap.AttributeID = AttributeID;
        //            pap.ProductID = product.ProductID;
        //            pap.AttributeValue = "";

        //            paRepo.Add(pap);
        //        }
        //    }


        //}
        //public static int GetMaxID(this ContractRepository repo)
        //{
        //    int ID = 0;
        //    //var dt = repo.GetAll();
        //    //if (dt.Count() > 0)
        //    //    ID = dt.Max(entity => entity.ActionParamID );
        //    return ID;
        //}
        //public static int Add(this ContractRepository repo, int ID, int ParamDataTypeID, string ParamName, int ExecutionActionID)
        //{
        //    //ActionParam actionParam = repo.GetLocal(a => a.DataTypeID == ParamDataTypeID && a.ParamName == ParamName && a.ExecActionID == ExecutionActionID);
        //    //if (actionParam == null)
        //    //{
        //    //    actionParam = new ActionParam
        //    //    {
        //    //        ActionParamID = ID,
        //    //        DataTypeID = ParamDataTypeID,
        //    //        ParamName = ParamName,
        //    //        ExecActionID = ExecutionActionID
        //    //    };
        //    //    repo.Add(actionParam);
        //    //}
        //    //return actionParam.ActionParamID;
        //    return 0;
        //}

        //public static int GetMaxID(this DataTypeRepository repo)
        //{
        //    int ID = 0;
        //    var dt = repo.GetAll();
        //    if (dt.Count() > 0)
        //        ID = dt.Max(entity => entity.DataTypeID);
        //    return ID;
        //}
        //public static int Add(this DataTypeRepository repo, int ID, string assemblyName, string ComponentName, string Namespace )
        //{
        //    DataType dataType = repo.GetLocal(a => a.AssemblyName == assemblyName && a.ClassName == ComponentName && a.Namespace == Namespace);
        //    if (dataType == null)
        //    {
        //        dataType = new DataType
        //        {
        //            DataTypeID = ID,
        //            AssemblyName = assemblyName,
        //            ClassName = ComponentName,
        //            Namespace = Namespace
        //        };
        //        repo.Add(dataType);
        //    }
        //    return dataType.DataTypeID;
        //}

        //public static int GetMaxID(this ExecActionRepository repo)
        //{
        //    int ID = 0;
        //    var dt = repo.GetAll();
        //    if (dt.Count() > 0)
        //        ID = dt.Max(entity => entity.ExecActionID);
        //    return ID;
        //}
        //public static int Add(this ExecActionRepository repo, int ID, string MethodName, int DataTypeID, string RequestModel, string ResponseModel)
        //{
        //    ExecAction executionAction = repo.GetLocal(a => a.ActionName == MethodName && a.DataTypeID == DataTypeID);
        //    if (executionAction == null)
        //    {
        //        executionAction = new ExecAction
        //        {
        //            ExecActionID = ID,
        //            DataTypeID = DataTypeID,
        //            ActionName = MethodName,
        //            RequestModel = RequestModel,
        //            ResponseModel = ResponseModel
        //        };
        //        repo.Add(executionAction);
        //    }
        //    return executionAction.ExecActionID;
        //}

        //public static ActionSignature GetActionSignature1(this UserRepository repo,  DBOption anOption)
        //{
        //    var list = (
        //        from option in repo.SprinxleDBContext.Option
        //        join execAction in repo.SprinxleDBContext.ExecAction
        //        on option.ExecActionID equals execAction.ExecActionID

        //        join component in repo.SprinxleDBContext.DataType
        //        on execAction.DataTypeID equals component.DataTypeID

        //        join param in repo.SprinxleDBContext.ActionParam
        //        on execAction.ExecActionID equals param.ExecActionID

        //        join paramType in repo.SprinxleDBContext.DataType
        //        on param.DataTypeID equals paramType.DataTypeID

        //        where
        //          option.OptionID == (int)anOption
        //        select new ActionSignature
        //        {
        //            ComponentAssemblyName = component.AssemblyName,
        //            ComponentNamespace = component.Namespace,
        //            ComponentClassName = component.ClassName,
        //            ActionName = execAction.ActionName,
        //            ParamName = param.ParamName,
        //            ParamTypeAssemblyName = paramType.AssemblyName,
        //            ParamTypeNamespace = paramType.Namespace,
        //            ParamTypeClassName = paramType.ClassName
        //        }).FirstOrDefault();
        //    return list;
        //}
    }
}
