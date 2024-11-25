export interface ServiceResponse<T>
{
    success: boolean;
    data: T | null;
    errorMessage: string | null;
}