package com.ankamagames.dofus.network.types.game.social
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.AllianceInformations;
   import com.ankamagames.dofus.network.types.game.guild.GuildEmblem;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class AllianceFactSheetInformations extends AllianceInformations implements INetworkType
   {
      
      public static const protocolId:uint = 421;
       
      
      public var creationDate:uint = 0;
      
      public function AllianceFactSheetInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 421;
      }
      
      public function initAllianceFactSheetInformations(param1:uint = 0, param2:String = "", param3:String = "", param4:GuildEmblem = null, param5:uint = 0) : AllianceFactSheetInformations
      {
         super.initAllianceInformations(param1,param2,param3,param4);
         this.creationDate = param5;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.creationDate = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AllianceFactSheetInformations(param1);
      }
      
      public function serializeAs_AllianceFactSheetInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AllianceInformations(param1);
         if(this.creationDate < 0)
         {
            throw new Error("Forbidden value (" + this.creationDate + ") on element creationDate.");
         }
         param1.writeInt(this.creationDate);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AllianceFactSheetInformations(param1);
      }
      
      public function deserializeAs_AllianceFactSheetInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._creationDateFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AllianceFactSheetInformations(param1);
      }
      
      public function deserializeAsyncAs_AllianceFactSheetInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._creationDateFunc);
      }
      
      private function _creationDateFunc(param1:ICustomDataInput) : void
      {
         this.creationDate = param1.readInt();
         if(this.creationDate < 0)
         {
            throw new Error("Forbidden value (" + this.creationDate + ") on element of AllianceFactSheetInformations.creationDate.");
         }
      }
   }
}
