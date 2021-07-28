import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class UsersProvider {
  createAccount(email: string, password: string): any {
    throw new Error("Method not implemented.");
  }
  private API_URL = 'http://localhost:5000/api/'
  constructor(public http: Http) { }

  // createAccount(NomeCliente: string, CPF: string, Email: string, NomeUsuario: string, Senha: string, Nivel: string) {
  //   return new Promise((resolve, reject) => {
  //     var data = {
  //       NomeCliente: NomeCliente,
  //       CPF: CPF,
  //       Email: Email,
  //       NomeUsuario: NomeUsuario,
  //       Senha: Senha,
  //       Nivel: Nivel

  //     };

  //     this.http.post(this.API_URL + 'usuario', data)
  //       .subscribe((result: any) => {
  //         resolve(result.json());
  //       },
  //       (error) => {
  //         reject(error.json());
  //       });
  //   });
  // }

  login(nomeUsuario: string, senha: string) {
    return new Promise((resolve, reject) => {
      var dados = {
        nomeUsuario: nomeUsuario,
        senha: senha
      };

      this.http.post(this.API_URL + 'login', dados)
        .subscribe((result: any) => {
          resolve(result.json());
        },
        (error) => {
          reject(error.json());
        });
    });
  }

  createEvent(name: string, address: string, rua: string, data: string, inicio: string, termino: string, type: string, preco: string) {
    return new Promise((resolve, reject) => {
      var dados = {
        name: name,
        address: address,
        rua: rua,
        data:data,       
        inicio: inicio,
        termino: termino,
        type: type,
        preco: preco

      };

      this.http.post(this.API_URL + 'markers', dados)
        .subscribe((result: any) => {
          resolve(result.json());
        },
        (error) => {
          reject(error.json());
        });
    });
  }



  // getAll(page: number) {
  //   return new Promise((resolve, reject) => {

  //     let url = this.API_URL + 'markers';

  //     this.http.get(url)
  //       .subscribe((result: any) => {
  //         resolve(result.json());
  //       },
  //       (error) => {
  //         reject(error.json());
  //       });
  //   });
  // }

  // get(id: number) {
  //   return new Promise((resolve, reject) => {
  //     let url = this.API_URL + 'markers' + id;

  //     this.http.get(url)
  //       .subscribe((result: any) => {
  //         resolve(result.json());
  //       },
  //       (error) => {
  //         reject(error.json());
  //       });
  //   });
  // }

  // insert(user: any) {
  //   return new Promise((resolve, reject) => {
  //     let url = this.API_URL + 'users/';

  //     this.http.post(url, user)
  //       .subscribe((result: any) => {
  //         resolve(result.json());
  //       },
  //       (error) => {
  //         reject(error.json());
  //       });
  //   });
  // }

  // update(user: any) {
  //   return new Promise((resolve, reject) => {
  //     let url = this.API_URL + 'users/' + user.id;
  //     let data = {
  //       "first_name": user.first_name,
  //       "last_name": user.last_name
  //     }

  //     this.http.put(url, user)
  //       .subscribe((result: any) => {
  //         resolve(result.json());
  //       },
  //       (error) => {
  //         reject(error.json());
  //       });
  //   });
  // }

  // remove(id: number) {
  //   return new Promise((resolve, reject) => {
  //     let url = this.API_URL + 'users/' + id;

  //     this.http.delete(url)
  //       .subscribe((result: any) => {
  //         resolve(result.json());
  //       },
  //       (error) => {
  //         reject(error.json());
  //       });
  //   });
  // }
}