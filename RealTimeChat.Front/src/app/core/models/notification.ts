import { Message } from "./message";
import { User } from "./User";

export interface Notification
{
    seen: boolean;
    message: Message;
    user: User;
}