import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { CookieService} from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private CookieService: CookieService  ) {  }

  getUsers(): Observable<User[]> { return this.http.get<User[]>(`${environment.apiBaseUrl}/api/Users`)} 
}
