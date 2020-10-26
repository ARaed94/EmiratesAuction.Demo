import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class NotifyService {

    public notifier = new Subject<any>();

    constructor() { }

    sendCriteria(criteria: any) {
        this.notifier.next(criteria);
    }
}