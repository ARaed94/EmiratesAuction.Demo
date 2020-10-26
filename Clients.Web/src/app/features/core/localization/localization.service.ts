import { Injectable } from '@angular/core';
import { EnglishResources } from 'src/app/resources/en';
import { ArabicResources } from 'src/app/resources/ar';
import { StorageService } from '../storage/storage.provider';

export interface Message {
    fromName: string;
    subject: string;
    date: string;
    id: number;
    read: boolean;
}

@Injectable({
    providedIn: 'root'
})

export class LocalizationService {
    constructor() { }

    public setDefaultLanguage() {
        let htmlTag = document.getElementsByTagName("html")[0] as HTMLHtmlElement;
        let lang = this.readAndSetLanguage();

        if (lang == "en") {
            StorageService.setItem("Resources", JSON.stringify(EnglishResources));
            htmlTag.dir = "ltr";
        }
        else if (lang == "ar") {
            StorageService.setItem("Resources", JSON.stringify(ArabicResources));
            htmlTag.dir = "rtl";
        }
    }

    public toggleLanguage() {
        let htmlTag = document.getElementsByTagName("html")[0] as HTMLHtmlElement;
        let lang = this.readAndSetLanguage();

        if (lang == "en") {
            // Toggle language to Arabic.
            StorageService.setItem("lang", "ar");
        }
        else if (lang == "ar") {
            // Toggle language to Arabic.
            StorageService.setItem("lang", "en");
        }
        location.reload();
    }

    public readAndSetLanguage(): string {
        let lang = StorageService.getItem("lang");
        if (lang == null) {
            StorageService.setItem("lang", "en");
            return "en";
        }
        else return lang;
    }
}

