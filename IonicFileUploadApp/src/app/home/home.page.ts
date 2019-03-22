import { Component } from '@angular/core';
import { NavController, NavParams, ToastController
, ActionSheetController, AlertController, LoadingController } from '@ionic/angular';
import { Headers, Http, Response } from '@angular/http';
import { Camera, CameraOptions } from '@ionic-native/camera';
@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {


  constructor(public http: Http, public toastCtrl: ToastController, 
  public loadingCtrl: LoadingController, public navCtrl: NavController, 
  public navParams: NavParams, private camera: Camera, private actionsheetCtrl: ActionSheetController, 
  private storage: Storage, private alertCtrl: AlertController, public loader: LoadingController){

  }
}
