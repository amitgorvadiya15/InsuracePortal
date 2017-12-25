
//stores sites on the page - assoc table: key; page number + title
var available_sites = new Array();

/*
 * available_sites['home'] = new Array(1,'Landlord Town');
 * available_sites['larry-wants-to-rent-his-house'] = new
 * Array(2,'larry-wants-to-rent-his-house');
 * available_sites['using-letting-agency'] = new
 * Array(3,'using-letting-agency'); available_sites['pre-rental-checklist'] =
 * new Array(4,'pre-rental-checklist');
 * available_sites['signing-tenancy-agreement'] = new
 * Array(5,'signing-tenancy-agreement');
 * available_sites['getting-landlord-insurance'] = new
 * Array(6,'getting-landlord-insurance'); available_sites['finding-tradesman'] =
 * new Array(7,'finding-tradesman'); available_sites['gas-safety-checks'] = new
 * Array(8,'gas-safety-checks'); available_sites['tax-on-rental-profits'] = new
 * Array(9,'tax-on-rental-profits'); available_sites['evicting-tenants'] = new
 * Array(10,'evicting-tenants'); available_sites['the-end'] = new
 * Array(11,'the-end');
 */

// link + title
available_sites[1] = new Array('home', 'Landlord Town');
available_sites[2] = new Array('larry-wants-to-rent-his-house',
		'Larry wants to rent out his house');
available_sites[3] = new Array('using-letting-agency', 'Using a letting agency');
available_sites[4] = new Array('pre-rental-checklist', 'Pre-rental checklist');
available_sites[5] = new Array('signing-tenancy-agreement',
		'Signing a tenancy agreement');
available_sites[6] = new Array('getting-landlord-insurance',
		'Getting landlord insurance');
available_sites[7] = new Array('finding-tradesman', 'Finding a tradesman');
available_sites[8] = new Array('gas-safety-checks', 'Gas safety checks');
available_sites[9] = new Array('tax-on-rental-profits', 'Tax on rental profits');
available_sites[10] = new Array('evicting-tenants', 'Evicting tenants');
available_sites[11] = new Array('the-end', 'Larry has found a tenant!');

function getPageNumber(page) {
	var i = 1;
	var found = false;

	while (i < available_sites.length && !found) {
		if (available_sites[i][0] == page) {
			found = true;
		} else
			i++;
	}

	if (found)
		return i;
	else
		return -1;
}

function getPageTitle(page) {
	var page_number = getPageNumber(page);

	if (page_number != -1)
		return available_sites[page_number][1];
	else
		return '';
}

function getNextPagesLink(page) {
	var current_number = getPageNumber(page);
	var next_number = current_number + 1;

	if (next_number - 1 <= available_sites.length)
		return available_sites[next_number][0];
}

function getPrevPagesLink(page) {

	var current_number = getPageNumber(page);
	var next_number = current_number - 1;

	if (next_number > 0)
		return available_sites[next_number][0];
}
