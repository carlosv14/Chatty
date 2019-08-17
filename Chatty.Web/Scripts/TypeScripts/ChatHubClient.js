var ChatHubClient = /** @class */ (function () {
    function ChatHubClient() {
        var _this = this;
        this.started = false;
        this.hub = $.connection.chatHub;
        this.hub.client.sendMessage = this.receiveMessage;
        $.connection.hub.start().done(function () {
            _this.started = true;
            console.log("conectado");
        });
    }
    ChatHubClient.prototype.hasStarted = function () {
        return this.started;
    };
    ChatHubClient.prototype.receiveMessage = function (message) {
        $("#messageBox").append("<div class=\"alert alert-primary\" role=\"alert\">" + message + "</div>");
    };
    ChatHubClient.prototype.sendMessage = function (message) {
        this.hub.server.sendMessage(message);
    };
    return ChatHubClient;
}());
//# sourceMappingURL=ChatHubClient.js.map