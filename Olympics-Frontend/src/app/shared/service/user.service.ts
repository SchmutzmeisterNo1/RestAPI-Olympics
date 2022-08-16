import { Injectable } from "@angular/core";
import { AuthenticateRequest } from "../models/authenticate-request.model";
import { AuthenticateResponse } from "../models/authenticate-response.model";
import { User } from "../models/user.model";
import { BaseService } from "./base.service";



@Injectable()
export class UserService extends BaseService {
    userSession: AuthenticateResponse;
    user: User;
    loadedUser: boolean = false;

    authenticate = async (request: AuthenticateRequest): Promise<AuthenticateResponse> => {
        const userSession = await super.httpPost<AuthenticateResponse>('Auth/login', request);
        this.userSession = userSession;
        this.user = userSession.User;
        this.saveUserSession();
        console.log(userSession);
        return userSession;
    };

    isLoggedIn(): boolean {
        return this.userSession.User != null;
    }

    private saveUserSession() {
        window.localStorage.setItem('user', JSON.stringify(this.userSession));
    }

    public hasUserSession(): boolean {
        return window.localStorage.getItem('user') != null;
    }

    public async restoreUserSession(): Promise<void> {
        const user = window.localStorage.getItem('user');
        if (user) {
            this.userSession = JSON.parse(user);
            this.user = this.userSession.User;
        }
        if (user && !this.loadedUser) {
            this.user = await this.getUser(this.user.Id);
            this.loadedUser = true;
        }
    }

    clearUserSession(clearInStorage: boolean) {
        if (clearInStorage) {
            localStorage.removeItem('user');
        }
    }

    logout() {
        const loginUrl = document.location.origin + '/login';
        this.clearUserSession(true);
        document.location.href = loginUrl;
    }

    async getUser(id: any): Promise<User> {
        return await super.httpGet<User>(`user/getUser/${id}`);
    }
}
