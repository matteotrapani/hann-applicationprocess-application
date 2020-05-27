import {autoinject} from 'aurelia-framework';
import {PLATFORM} from 'aurelia-pal';
import {Router, RouterConfiguration} from 'aurelia-router';
import {I18N} from 'aurelia-i18n';

@autoinject
export class App {
  public router: Router;

  constructor(private i18n: I18N) {
  }

  public configureRouter(config: RouterConfiguration, router: Router) {
    config.title = 'Hahn.ApplicatonProcess.Application';
    config.map([
      {
        route: ['', 'welcome'],
        name: 'welcome',
        moduleId: PLATFORM.moduleName('./welcome'),
        nav: true,
        title: 'Welcome'
      },
      {
        route: 'applicants',
        name: 'applicants',
        moduleId: PLATFORM.moduleName('./applicants-list'),
        nav: true,
        title: this.i18n.tr('applicants.list.title')
      },
      {
        route: 'applicants/add',
        name: 'addApplicant',
        moduleId: PLATFORM.moduleName('./applicants-add'),
        nav: false,
        title: this.i18n.tr('applicants.add.title')
      },
      {
        route: 'applicants/:id', 
        name:'editApplicant',
        moduleId: PLATFORM.moduleName('./applicant-edit'), 
        nav: false,
        title: this.i18n.tr('applicants.edit.title')
      }
    ]);

    this.router = router;
  }
}
