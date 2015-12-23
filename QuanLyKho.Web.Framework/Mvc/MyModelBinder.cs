using System.Web.Mvc;

namespace QuanLyKho.Web.Framework.Mvc
{
    public class MyModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = base.BindModel(controllerContext, bindingContext);
            if (model is BaseMyModel)
            {
                ((BaseMyModel)model).BindModel(controllerContext, bindingContext);
            }
            return model;
        }
    }
}
