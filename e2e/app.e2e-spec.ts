import { rmiMedicineDoctorPage } from './app.po';

describe('rmiMedicineDoctor App', () => {
  let page: rmiMedicineDoctorPage;

  beforeEach(() => {
    page = new rmiMedicineDoctorPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
