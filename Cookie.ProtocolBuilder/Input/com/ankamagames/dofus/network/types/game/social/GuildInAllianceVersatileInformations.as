package com.ankamagames.dofus.network.types.game.social
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class GuildInAllianceVersatileInformations extends GuildVersatileInformations implements INetworkType
   {
      
      public static const protocolId:uint = 437;
       
      
      public var allianceId:uint = 0;
      
      public function GuildInAllianceVersatileInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 437;
      }
      
      public function initGuildInAllianceVersatileInformations(param1:uint = 0, param2:Number = 0, param3:uint = 0, param4:uint = 0, param5:uint = 0) : GuildInAllianceVersatileInformations
      {
         super.initGuildVersatileInformations(param1,param2,param3,param4);
         this.allianceId = param5;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.allianceId = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GuildInAllianceVersatileInformations(param1);
      }
      
      public function serializeAs_GuildInAllianceVersatileInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GuildVersatileInformations(param1);
         if(this.allianceId < 0)
         {
            throw new Error("Forbidden value (" + this.allianceId + ") on element allianceId.");
         }
         param1.writeVarInt(this.allianceId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildInAllianceVersatileInformations(param1);
      }
      
      public function deserializeAs_GuildInAllianceVersatileInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._allianceIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildInAllianceVersatileInformations(param1);
      }
      
      public function deserializeAsyncAs_GuildInAllianceVersatileInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._allianceIdFunc);
      }
      
      private function _allianceIdFunc(param1:ICustomDataInput) : void
      {
         this.allianceId = param1.readVarUhInt();
         if(this.allianceId < 0)
         {
            throw new Error("Forbidden value (" + this.allianceId + ") on element of GuildInAllianceVersatileInformations.allianceId.");
         }
      }
   }
}
