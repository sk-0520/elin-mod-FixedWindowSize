namespace Elin.Plugin.Main.Models.Impl
{
    public static class CoreConfigImpl
    {
        #region function

        public static void ApplyResolutionPostfix(CoreConfig instance)
        {
            var arekore = new WindowArekore();
            arekore.ChangeWindowStyle(instance.graphic.fullScreen, instance.graphic.fixedResolution);
        }

        #endregion
    }
}
