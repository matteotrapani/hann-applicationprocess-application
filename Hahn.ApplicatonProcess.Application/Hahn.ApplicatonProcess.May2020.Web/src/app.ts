import {PLATFORM} from 'aurelia-pal';
import {Router, RouterConfiguration} from 'aurelia-router';

export class App {
  public router: Router;

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
        title: 'Applicants'
      }
    ]);

    this.router = router;
  }
}
