
export interface Message
{
    id: number;
    mediaUrl: string|null;
    body: string;
    seen: boolean;
    date: Date;
    senderId: number;
}