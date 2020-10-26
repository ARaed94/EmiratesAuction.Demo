import { Subject } from 'rxjs';
import { StorageService } from '../storage/storage.provider';

export abstract class BaseComponent {

    constructor() {
    }

    public Localize(key: string): string {
        if (key == null || key == "") { return null }
        let resources = JSON.parse(StorageService.getItem("Resources"));
        return resources[key];
    }

    public LocalizedText(arabic: string, english: string): string {
        let lang = StorageService.getItem("lang");
        if (lang == null) {
            StorageService.setItem("lang", "en");
            lang = "en";
        }

        if (lang == "ar") {
            return (((!arabic || arabic.replace(/\s/g, '').length == 0)) ? english : arabic);
        }
        else {
            return (((!english || !english.replace(/\s/g, '').length)) ? arabic : english);
        }
    }
}


