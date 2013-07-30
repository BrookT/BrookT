<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testPage.aspx.cs" Inherits="PageMoveTest1307291438.testPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <style>
        body, form, div
        {
            float: none;
            margin-top: 0px;
            margin-left: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            padding: 0;
        }

        body
        {
            overflow-y: hidden;
            overflow-x: hidden;
        }

        .container-div
        {
            width: 100%;
            float: none;
            margin-top: 0px;
            margin-left: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            padding: 0;
            overflow: hidden;
        }

        .downBtn
        {
            text-align: center;
            vertical-align: middle;
            font-size: large;
            font-family: 迷你简卡通;
            position: fixed;
            bottom: 0px;
        }

        .content-div
        {
            position: absolute;
        }

        .canvas-div
        {
            position: relative;
        }
    </style>
</head>
<body>
    <div id="canvas-div">
        <div id="div1" class="container-div">
            <div class="content-div">div1</div>
        </div>
        <div id="div2" class="container-div">
            <div class="content-div">div2</div>
        </div>
        <div id="div3" class="container-div">
            <div class="content-div">div3</div>
        </div>
        <div id="div4" class="container-div">
            <div class="content-div">div4</div>
        </div>
    </div>
    <div class="downBtn">
    </div>
    <div class="upBtn">

    </div>
    <script>
        $("div").css("width", "100%");
        $(".container-div").css("border-width", "2px").css("border-color", "orange").css("border-style", "solid");
        $(".downBtn").text('read more...').css("background-color", "#ddd");//.css("position","absolute")
    </script>
    <script>
        var downTime = 0;
        var downTimeMax = 5;
        var windowHeight = document.documentElement.clientHeight + 'px';// window.screen.height
        var tabHeight = document.documentElement.clientHeight * 0.1 + 'px';
        var tabMarginTop = document.documentElement.clientHeight * 0.9 + 'px';
        $(".container-div").css("height", windowHeight);
        $(".downBtn").css("height", tabHeight).css("line-height", tabHeight).css("margin-bottom", "0px").css("margin-top", tabMarginTop);
        $(".downBtn").click(function () {
            //slide
            if (downTime >= downTimeMax)
            { return; }
            else
            {
                downTime++;
                $("#canvas-div").animate({ marginTop: '-' + document.documentElement.clientHeight * downTime + 'px' });//.animate({ "top": "958px" })
            }
        });
    </script>
</body>
</html>
