import { BearerAuthInterceptor } from "./bearer-auth.interceptor";
import { ErrorInterceptor } from "./error.interceptor";

export const interceptors = [
    BearerAuthInterceptor,
    ErrorInterceptor
]