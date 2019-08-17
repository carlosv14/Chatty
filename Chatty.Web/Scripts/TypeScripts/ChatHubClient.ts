class ChatHubClient {

    private hub: any;
    private started = false;

    constructor() {
        this.hub = $.connection.chatHub;
        this.hub.client.sendMessage = this.receiveMessage;
        $.connection.hub.start().done(() => {
            this.started = true;
            console.log("conectado");
        });
    }

    public hasStarted(): boolean{
        return this.started;
    }

    private receiveMessage(message: string): void {
        $("#messageBox").append(`<div class="alert alert-primary" role="alert">${message}</div>`)
    }

    public sendMessage(message: string): void {
        this.hub.server.sendMessage(message);
    }
}

declare var $: any;