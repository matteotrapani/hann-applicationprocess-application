import 'bootstrap';
import '@fortawesome/fontawesome-free';
import {Aurelia} from 'aurelia-framework';
import * as environment from '../config/environment.json';
import {PLATFORM} from 'aurelia-pal';
import { TCustomAttribute, Backend, I18N} from 'aurelia-i18n';
import { ValidationMessageProvider } from 'aurelia-validation';

export function configure(aurelia: Aurelia) {
  aurelia.use
    .standardConfiguration()
    .feature(PLATFORM.moduleName('resources/index'));

  aurelia.use.developmentLogging(environment.debug ? 'debug' : 'warn');

  if (environment.testing) {
    aurelia.use.plugin(PLATFORM.moduleName('aurelia-testing'));
  }

  aurelia.use
    .plugin(PLATFORM.moduleName('aurelia-validation'))
    .plugin(PLATFORM.moduleName('aurelia-dialog'))
    .plugin(PLATFORM.moduleName('aurelia-i18n'), (instance) => {
      let aliases = ['t', 'i18n'];
      // add aliases for 't' attribute
      TCustomAttribute.configureAliases(aliases);
  
      // register backend plugin
      instance.i18next.use(Backend.with(aurelia.loader));

      // adapt options to your needs (see http://i18next.com/docs/options/)
      // make sure to return the promise of the setup method, in order to guarantee proper loading
      return instance.setup({
        backend: {                                  // <-- configure backend settings
          loadPath: 'locales/{{lng}}/{{ns}}.json', // <-- XHR settings for where to get the files from
        },
        attributes: aliases,
        lng : 'en',
        fallbackLng : 'en',
        debug : false
      });
    });

  //Uncomment the line below to enable animation.
  // aurelia.use.plugin(PLATFORM.moduleName('aurelia-animator-css'));
  //if the css animator is enabled, add swap-order="after" to all router-view elements

  //Anyone wanting to use HTMLImports to load views, will need to install the following plugin.
  // aurelia.use.plugin(PLATFORM.moduleName('aurelia-html-import-template-loader'));
  
  ValidationMessageProvider.prototype.getMessage = function(key) {
    const i18n = aurelia.container.get(I18N);
    const translation = i18n.tr(`errorMessages.${key}`);
    return this.parser.parse(translation);
  };

  ValidationMessageProvider.prototype.getDisplayName = (propertyName: string | number, displayName?: string | null | (() => string)): string => {
    if (displayName !== null && displayName !== undefined) {
      return displayName.toString();
    }
    const i18n = aurelia.container.get(I18N);
    return i18n.tr(propertyName.toString());
  };

  aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
}
