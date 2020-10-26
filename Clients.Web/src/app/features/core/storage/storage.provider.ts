export class StorageService {

    constructor() {
    }

    public static getItem(key: string): any {
        if (key == null) {
            return null;
        }
        return localStorage.getItem(key);
    }

    public static setItem(key: string, value: any): void {
        if (key == null || value == null) {
            return null;
        }

        if (typeof value === 'object' && value !== null) {
            let obj = JSON.parse(value);
            localStorage.setItem(key, obj);
        }
        else {
            localStorage.setItem(key, value);
        }
    }

    public static delete(key: string): void {
        if (key == null) {
            return null;
        }
        localStorage.removeItem(key);
    }

    public static clear() {
        localStorage.clear();
    }
}
