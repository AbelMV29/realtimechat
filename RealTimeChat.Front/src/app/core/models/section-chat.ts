import { Message } from "./message";
import { User } from "./user";

export interface SectionChat
{
    user: User;
    lastMessage: Message;
}