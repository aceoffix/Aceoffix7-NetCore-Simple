# Aceoffix7-NetCore-Simple

**Latest Version：7.0.1.1**

### 1. Introduction

The Aceoffix7-NetCore-Simple project demonstrates how to use the Aceoffix 7.0 product within the ASP.NET Core. Please note that this project only supports ASP.NET Core and does not cover the ASP.NET Framework. It supports .NET Core 3.1, as well as .NET 5 and later versions. This project showcases the simplest way to open, edit, and save Word files on web pages.

### 2. Project environmental prerequisites

​    Visual Studio 2019 or later versions.

### 3. Steps for running the project

- Use "git clone" or directly download the project's compressed package to your local machine and then decompress it.

- Download the Aceoffix client program.

  [aceclientsetup_7.0.1.1.exe](https://github.com/aceoffix/aceoffix7-client/releases/download/v7.0.1.1/aceclientsetup_7.0.1.1.exe)

- Copy the program downloaded in the previous step to the root directory of the current project.

- Open this project using Visual Studio. Then right-click on the project folder, and click "Manage NuGet Packages -> Browse" in sequence. Enter "Acesoft.Aceoffix" in the search box and install the latest version.

- Run this project  to see the sample effect.

### 4. Trial license key

- Aceoffix Standard V7.0 is 4ZDGS-FDZDK-WK18-YSJET

- Aceoffix Enterprise V7.0 is QA2JS-8C0PT-IKKJ-VTCC6

- Aceoffix Ultimate V7.0 is 9GRX9-VFFED-6NSN-ACVR1


### 5. How to integrate AceoffixV7 into your web project

-  Open this project using Visual Studio. Then right-click on the project folder, and click "Manage NuGet Packages -> Browse" in sequence. Enter "Acesoft.Aceoffix" in the search box and install the latest version.

- Download the Aceoffix client program.

​    [aceclientsetup_7.0.1.1.exe](https://github.com/aceoffix/aceoffix7-client/releases/download/v7.0.1.1/aceclientsetup_7.0.1.1.exe)

- Copy the program downloaded in the previous step to the root directory of your project. Then, in Visual Studio, right - click on the program and change the value of "Properties -> Copy to Output Directory" to "Copy always".

- Add the following code to  your project `Program.cs` file.

  ```
  app.UseMiddleware<AceoffixNetCore.AceServer.ServerHandlerMiddleware>();
  ```

-  Reference aceoffix.js in the <head> tag of the _Layout.cshtml page of your project.

  ```javascript
  <script type="text/javascript" src="aceoffix.js"></script>
  ```

>  Note: The path of aceoffix.js is relative to the root of your website.

​     Write the following link to pop up an Acebrowser window to edit Office document. We assume that the page which contains Aceoffix control is    "Views/Home/Index.cshtml".

```html
 <a href="javascript:AceBrowser.openWindow('Word/Index',  'width=1150px;height=900px;');">Open Word File</a>
```

- Then, write the following server code in "Controllers/WordController.cs".

```c#
public IActionResult Index()
{
    AceoffixNetCore.AceoffixCtrl aceCtrl= new AceoffixNetCore.AceoffixCtrl(Request);
    aceCtrl.SaveFilePage = "Save";
    aceCtrl.WebOpen("/doc/editword.docx", AceoffixNetCore.OpenModeType.docNormalEdit, "tom");
    ViewBag.aceCtrl = aceCtrl.GetHtml();
    return View();
}
```

- 
  Add a new function called Save in  "Controllers/WordController.cs"  if your user wants to save document.


```c#
public async Task<ActionResult> Save()
{
    AceoffixNetCore.FileSaver fs = new AceoffixNetCore.FileSaver(Request, Response);
    await fs.LoadAsync();
    string webRootPath = _webHostEnvironment.WebRootPath;
    fs.SaveToFile(webRootPath + "/doc/" + fs.FileName);
    return fs.Close();
}
```

-  Please continue with the front-end code for the "Views/Word/Index.cshtml".


```aspx
@{
    Layout = null;
}
<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
    <script type="text/javascript">
        function SaveDoc() {
            aceoffixctrl.WebSave();
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "SaveDoc()", 1);
        }
    </script>
</head>
<body>
    <div style=" width:auto; height:98vh;">
        @Html.Raw(ViewBag.aceCtrl)
    </div>
</body>
</html>
```

-  When publish the project , follow the prompts to install the Aceoffix V7 client. Once the registration dialog box appears, please enter the license key of Aceoffix V7 to complete the registration.

