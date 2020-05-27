import {PLATFORM} from 'aurelia-pal';
import {Router, RouterConfiguration} from 'aurelia-router';

export class ChildRouter {
  public heading = 'Child Router';
  public router: Router;

  public configureRouter(config: RouterConfiguration, router: Router) {
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
        title: 'Applicants'
      },
      {
        route: 'applicants/add',
        name: 'addApplicant',
        moduleId: PLATFORM.moduleName('./applicants-add'),
        nav: false,
      },
      {
        route: 'applicants/:id', 
        moduleId: PLATFORM.moduleName('./applicant-edit'), 
        name:'editApplicant'
      }
    ]);

    this.router = router;
  }
}
