export interface MessageSend{
    body: string,
    mediaUrl: File | null,
    receiverId: number;
}