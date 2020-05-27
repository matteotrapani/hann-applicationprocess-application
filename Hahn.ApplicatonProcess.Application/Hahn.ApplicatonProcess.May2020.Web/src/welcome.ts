import {autoinject} from 'aurelia-framework';
import { I18N } from 'aurelia-i18n';
import { Router } from 'aurelia-router';

@autoinject
export class Welcome {
  public heading: string = 'Welcome to the Aurelia Navigation App!';

  constructor(private i18n: I18N, private router: Router) {
  }
}

export class UpperValueConverter {
  public toView(value: string): string {
    return value && value.toUpperCase();
  }
}
