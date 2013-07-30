<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testPage.aspx.cs" Inherits="PageMoveTest1307291438.testPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Drag Down Test</title>
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
            cursor: pointer;
        }

        .content-div
        {
            position: absolute;
        }

        .canvas-div
        {
            position: relative;
        }

        .upBtn
        {
            position: fixed;
            background-image: url('Images/973.png');
            background-repeat: no-repeat;
            background-size: cover;
        }

        .btn
        {
            cursor: pointer;
        }

        .topTab
        {
            position: absolute;
            top: 0;
            width: 100%;
            background-color: #ccc;
            z-index: 1000;
        }
    </style>
</head>
<body>
    <div class="topTab">Header</div>
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
    <div class="upBtn btn">
    </div>
    <script>
        $(".container-div").css("border-width", "1px").css("border-color", "orange").css("border-style", "solid");
        $(".downBtn").text('read more...').css("background-color", "#ddd").css("width", "100%");//.css("position","absolute")
    </script>
    <script>
        var changeSpd = 1000;
        var changeSpdQuick = 500;
        var changeSpdSlow = 2000;
        var downTime = 0;
        var downTimeMax = 4;
        var windowHeight = document.documentElement.clientHeight + 'px';// window.screen.height
        var tabHeight = document.documentElement.clientHeight * 0.1 + 'px';
        var rollTopRight = rollTopBottom = document.documentElement.clientHeight * 0.1 + 'px';
        var rollTopWidth = rollTopHeight = document.documentElement.clientHeight * 0.1 + 'px';
        var tabMarginTop = document.documentElement.clientHeight * 0.9 + 'px';
        $(function () {
            initPage();
            bindEvents();
        });
        function initPage() {
            $(".container-div").css("height", windowHeight);
            $(".downBtn").css("height", tabHeight).css("line-height", tabHeight).css("bottom", "0px").css("top", tabMarginTop);
            $(".upBtn").css("height", rollTopHeight).css("width", rollTopWidth).css("right", rollTopRight).css("bottom", rollTopBottom).hide();
            $(".topTab").css("height", tabHeight).css("line-height", tabHeight);
        }
        function bindEvents() {
            $(".downBtn").click(function () {
                //slide
                downTime++;
                if (downTime > downTimeMax)
                { return; }
                else
                {
                    if (downTime == downTimeMax) {
                        Roll.rollTop("canvas-div");
                    }
                    else {
                        Roll.rollDown("canvas-div", document.documentElement.clientHeight * downTime + 2);
                    }
                }
            });
            $(".upBtn").click(function () {
                Roll.rollTop("canvas-div");
            });
            $(".downBtn").mouseout(function () {
                //Tab.hideTab("downBtn");
            }).mouseover(function () {
                //Tab.showTab("downBtn");
            });
        }

        var Roll = {
            rollDown: function (obj, instance) {
                if (downTime >= 1) {
                    this.showRollTop();
                }
                if (downTime == downTimeMax-1) {
                    Tab.hideTab("downBtn");
                }
                $("#" + obj).animate({ marginTop: '-' + instance + 'px' });
            },
            rollTop: function (obj) {
                downTime = 0;
                this.hideRollTop();
                Tab.showTab("downBtn");
                $("#" + obj).animate({ marginTop: '0px' });
            },
            showRollTop: function () {
                $("." + 'upBtn').fadeIn(changeSpdQuick);
            },
            hideRollTop: function () {
                $("." + 'upBtn').fadeOut(changeSpdQuick);
            }
        };
        var Tab = {
            showTab: function (obj) {
                $("." + obj).fadeIn(changeSpdQuick);
            },
            hideTab: function (obj) {
                $("." + obj).fadeOut(changeSpdQuick);
            }
        };
    </script>
</body>
</html>
