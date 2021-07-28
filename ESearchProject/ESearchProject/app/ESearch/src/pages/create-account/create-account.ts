import { UsersProvider } from './../../providers/users/users';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, ToastController } from 'ionic-angular';

@IonicPage()
@Component({
  selector: 'page-create-account',
  templateUrl: 'create-account.html',
})
export class CreateAccountPage {
  model: User;

  constructor(public navCtrl: NavController, public navParams: NavParams, private toast: ToastController, private userProvider: UsersProvider) {
    this.model = new User();
    this.model.name
    this.model.address 
    this.model.rua 
    this.model.data 
    this.model.inicio 
    this.model.termino 
    this.model.type 
    this.model.preco 

  }

  createEvent() {
    this.userProvider.createEvent(this.model.name, this.model.address, this.model.rua, this.model.data, this.model.inicio, this.model.termino, this.model.type, this.model.preco)
      .then((result: any) => {
        this.toast.create({ message: 'Evento criado com sucesso. ' + result.token, position: 'botton', duration: 3000 }).present();

        //Salvar o token no Ionic Storage para usar em futuras requisições.
        //Redirecionar o usuario para outra tela usando o navCtrl
        //this.navCtrl.pop();
        //this.navCtrl.setRoot()
      })
      .catch((error: any) => {
        this.toast.create({ message: 'Erro ao criar o Evento. Erro: ' + error.error, position: 'botton', duration: 3000 }).present();
      });
  }
}

export class User {
  name: string;
  address: string;
  rua: string;
  data: string;
  inicio: string;
  termino: string;
  type: string;
  preco: string;
}