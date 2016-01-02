<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MineSweeperWeb.Templates.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <script src="/Scripts/angular.js"></script>
    <script src="/Scripts/angular-route.min.js"></script>
    <script src="/Scripts/angular-mocks.js"></script>
    <script src="/js/custom.js"></script>
    <script src="/Scripts/app/app.js"></script>
    <script src="/Scripts/app/controllers/MineSweeper.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid bg-info" ng-app="minesweeper">
        <div class="modal-dialog">
            <div class="modal-content" ng-controller="MineSweeperController">
                <div class="modal-header">{{ check }} {{ difficulty }}
                    <h3><span class="label label-warning" id="qid">  Choose Diffculty </span></h3>
                </div>
                <div class="modal-body">
                    <div class="col-xs-3 col-xs-offset-5">
                        <div id="loadbar" style="display: none;">
                            <div class="blockG" id="rotateG_01"></div>
                            <div class="blockG" id="rotateG_02"></div>
                            <div class="blockG" id="rotateG_03"></div>
                            <div class="blockG" id="rotateG_04"></div>
                            <div class="blockG" id="rotateG_05"></div>
                            <div class="blockG" id="rotateG_06"></div>
                            <div class="blockG" id="rotateG_07"></div>
                            <div class="blockG" id="rotateG_08"></div>
                        </div>
                    </div>

                    <div class="quiz" id="quiz" data-toggle="buttons" ng-init="getMines()">
                        <label class="element-animation1 btn btn-lg btn-green btn-block"><span class="btn-label"><i class="glyphicon glyphicon-chevron-right"></i></span>
                            <input type="radio" name="q_answer" ng-model="difficulty" value="1">Easy</label>
                        <label class="element-animation2 btn btn-lg btn-primary btn-block"><span class="btn-label"><i class="glyphicon glyphicon-chevron-right"></i></span>
                            <input type="radio" name="q_answer" ng-model="difficulty" value="2">Medium</label>
                        <label class="element-animation3 btn btn-lg btn-warning btn-block"><span class="btn-label"><i class="glyphicon glyphicon-chevron-right"></i></span>
                            <input type="radio" name="q_answer" ng-model="difficulty" value="3">Hard</label>
                        <label class="element-animation4 btn btn-lg btn-danger btn-block"><span class="btn-label"><i class="glyphicon glyphicon-chevron-right"></i></span>
                            <input type="radio" name="q_answer" ng-model="difficulty" value="4">Expert</label>
                    </div>
                </div>
                <div class="modal-footer text-muted">
                    <span id="answer"></span>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

