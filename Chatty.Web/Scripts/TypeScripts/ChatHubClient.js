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
        var messages = $("#messageBox").find("div");
        var id = messages.length;
        if (messages.length > 49) {
            messages.first().remove();
        }
        if (message.indexOf("bot:") !== -1) {
            $("#messageBox").append("<div id=\"message-" + id + "\" class=\"alert alert-success\" role=\"alert\">" + message + "</div>");
        }
        else {
            $("#messageBox").append("<div id=\"message-" + id + "\" class=\"alert alert-primary\" role=\"alert\">" + message + "</div>");
        }
    };
    ChatHubClient.prototype.sendMessage = function (message) {
        this.hub.server.sendMessage(message);
    };
    return ChatHubClient;
}());
//# sourceMappingURL=ChatHubClient.js.map