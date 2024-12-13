import { Module } from "@nestjs/common";
import { JobModule } from "./job/job.module";
import { StaffModule } from "./staff/staff.module";
import { RatingModule } from "./rating/rating.module";
import { PaymentModule } from "./payment/payment.module";
import { TransactionModule } from "./transaction/transaction.module";
import { SkillModule } from "./skill/skill.module";
import { WalletModule } from "./wallet/wallet.module";
import { PayrollModule } from "./payroll/payroll.module";
import { StaffAgencyModule } from "./staffAgency/staffAgency.module";
import { ApplicationModule } from "./application/application.module";
import { UserModule } from "./user/user.module";
import { HealthModule } from "./health/health.module";
import { PrismaModule } from "./prisma/prisma.module";
import { SecretsManagerModule } from "./providers/secrets/secretsManager.module";
import { ServeStaticModule } from "@nestjs/serve-static";
import { ServeStaticOptionsService } from "./serveStaticOptions.service";
import { ConfigModule } from "@nestjs/config";

import { LoggerModule } from "./logger/logger.module";

@Module({
  controllers: [],
  imports: [
    LoggerModule,
    JobModule,
    StaffModule,
    RatingModule,
    PaymentModule,
    TransactionModule,
    SkillModule,
    WalletModule,
    PayrollModule,
    StaffAgencyModule,
    ApplicationModule,
    UserModule,
    HealthModule,
    PrismaModule,
    SecretsManagerModule,
    ConfigModule.forRoot({ isGlobal: true }),
    ServeStaticModule.forRootAsync({
      useClass: ServeStaticOptionsService,
    }),
  ],
  providers: [],
})
export class AppModule {}
