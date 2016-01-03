<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MineSweeperWeb.Templates.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/angular.js"></script>
    <script src="/Scripts/angular-route.min.js"></script>
    <script src="/Scripts/angular-mocks.js"></script>
    <script src="/Scripts/angular-animate.min.js"></script>
    <script src="/Scripts/angular-ui/ui-bootstrap.min.js"></script>
    <script src="/Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script src="/Scripts/angular-aria.min.js"></script>
    <script src="/Scripts/angular-material.js"></script>
    <link href="/Content/angular-material/angular-material.css" rel="stylesheet" />
    <link href="/Content/ui-bootstrap-csp.css" rel="stylesheet" />
    <script src="/js/custom.js"></script>
    <script src="/Scripts/app/app.js"></script>
    <script src="/Scripts/app/controllers/MineSweeper.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div ng-app="minesweeper" ng-controller="MineSweeperController">
        <md-progress-linear md-mode="indeterminate"></md-progress-linear>
        <div class="container-fluid bg-info">
            <div class="modal-dialog">
                <div class="modal-content" ng-init="reload()">
                    <div class="modal-header">
                        <h3 ng-if="currentStatus === 'start'"><span class="label label-warning" id="qid">Choose Difficulty </span></h3>
                        <h3 ng-if="currentStatus !== 'start'" ng-click="reload();"><span class="btn btn-md btn-primary">Replay </span></h3>
                        <span class="label label-danger pull-right" ng-if="currentStatus !== 'start'">Total Mines : <span class="badge-warning">{{ mineCount }} </span></span>
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

                        <div class="quiz" id="quiz" data-toggle="buttons" ng-if="currentStatus === 'start'">
                            <label class="element-animation1 btn btn-lg btn-green btn-block" ng-click="beginGame('1')">
                                <span class="btn-label"><i class="glyphicon glyphicon-chevron-right"></i></span>
                                <input type="radio" name="q_answer" value="1">Easy</label>
                            <label class="element-animation2 btn btn-lg btn-primary btn-block" ng-click="beginGame('2')">
                                <span class="btn-label"><i class="glyphicon glyphicon-chevron-right"></i></span>
                                <input type="radio" name="q_answer" value="2">Medium</label>
                            <label class="element-animation3 btn btn-lg btn-warning btn-block" ng-click="beginGame('3')">
                                <span class="btn-label"><i class="glyphicon glyphicon-chevron-right"></i></span>
                                <input type="radio" name="q_answer" value="3">Hard</label>
                            <label class="element-animation4 btn btn-lg btn-danger btn-block" ng-click="beginGame('4')">
                                <span class="btn-label"><i class="glyphicon glyphicon-chevron-right"></i></span>
                                <input type="radio" name="q_answer" value="4">Expert</label>
                        </div>
                        {{currentStatus}}
                        <div ng-if="currentStatus === 'ingame'">
                            <md-content layout-padding>
                      <md-grid-list
                            md-cols-gt-md="{{mines.maxX}}" md-cols-sm="{{mines.maxX}}" md-cols-md="{{mines.maxX}}"
                            md-row-height-gt-md="1:1" md-row-height="4:3"
                            md-gutter-gt-md="4px" md-gutter-gt-sm="4px" md-gutter="4px">
                          <md-grid-tile
                              ng-repeat="box in mines.Boxes"
                              ng-style="{
                                'background':  boxColor 
                              }"
                              md-colspan-gt-sm="{{1}}"
                              md-rowspan-gt-sm="{{1}}" md-ink-ripple class="pointer" ng-click="boxClick(box.Position,box)" >
                              <span ng-if="box.clicked" class="badge-warning" ng-bind="box.AdjacentMines"></span>
                          </md-grid-tile>
                        </md-grid-list>
                      </md-content>
                        </div>


                    </div>
                    <div class="modal-footer text-muted">
                        <span id="answer"></span>
                    </div>
                </div>
            </div>

            <script type="text/ng-template" id="myModalContent.html">
        <div class="modal-header">
            <h3 class="modal-title"> <span class="label label-danger pull-warning" > Mine Blown Up!!</span></h3>
        </div>
        <div class="modal-body">
            <label class="btn btn-lg btn-primary btn-block" >
                                <span class="btn-label"><i class="glyphicon glyphicon-thumbs-down"></i></span>
                                GAME OVER!!</label>
        </div>
        <div class="modal-footer">
            <button class="btn btn-green" type="button" ng-click="ok()">Play Again</button>
        </div>
            </script>

        </div>
    </div>
</asp:Content>

