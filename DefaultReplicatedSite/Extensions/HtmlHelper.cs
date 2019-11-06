using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

/// <summary>
/// Extension Methods to help loading scripts/styles from partial views - maybe use bundling instead?
/// </summary>
public static class HtmlHelperExtensions
{
    private const string _ScriptViewContext = "RenderScriptHelper";
    private const string _StyleViewContext = "RenderStyleHelper";

    public static void AddScript(this HtmlHelper htmlHelper, string link)
    {
        if (htmlHelper.ViewContext.HttpContext.Items[_ScriptViewContext] is List<string> scriptList)
        {
            if (!scriptList.Contains(link))
            {
                scriptList.Add(link);
            }
        }
        else
        {
            scriptList = new List<string>();
            scriptList.Add(link);

            htmlHelper.ViewContext.HttpContext.Items.Add(_ScriptViewContext, scriptList);
        }
    }

    public static MvcHtmlString RenderHelperScripts(this HtmlHelper HtmlHelper)
    {
        StringBuilder result = new StringBuilder();

        if (HtmlHelper.ViewContext.HttpContext.Items[_ScriptViewContext] is List<string> scriptList)
        {
            foreach (string script in scriptList)
            {
                result.AppendLine(string.Format(
                    "<script type=\"text/javascript\" src=\"{0}\"></script>",
                    script));
            }
        }

        return MvcHtmlString.Create(result.ToString());
    }

    public static void AddStyle(this HtmlHelper htmlHelper, string link)
    {
        if (htmlHelper.ViewContext.HttpContext.Items[_StyleViewContext] is List<string> styleList)
        {
            if (!styleList.Contains(link))
            {
                styleList.Add(link);
            }
        }
        else
        {
            styleList = new List<string>();
            styleList.Add(link);
            htmlHelper.ViewContext.HttpContext
                .Items.Add(_StyleViewContext, styleList);
        }
    }

    public static MvcHtmlString RenderHelperStyles(this HtmlHelper htmlHelper)
    {
        StringBuilder result = new StringBuilder();

        if (htmlHelper.ViewContext.HttpContext.Items[_StyleViewContext] is List<string> styleList)
        {
            foreach (string script in styleList)
            {
                result.AppendLine(string.Format(
                    "<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\" />",
                    script));
            }
        }

        return MvcHtmlString.Create(result.ToString());
    }
}