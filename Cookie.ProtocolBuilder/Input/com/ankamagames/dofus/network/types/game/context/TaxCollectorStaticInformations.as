package com.ankamagames.dofus.network.types.game.context
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.GuildInformations;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class TaxCollectorStaticInformations implements INetworkType
   {
      
      public static const protocolId:uint = 147;
       
      
      public var firstNameId:uint = 0;
      
      public var lastNameId:uint = 0;
      
      public var guildIdentity:GuildInformations;
      
      private var _guildIdentitytree:FuncTree;
      
      public function TaxCollectorStaticInformations()
      {
         this.guildIdentity = new GuildInformations();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 147;
      }
      
      public function initTaxCollectorStaticInformations(param1:uint = 0, param2:uint = 0, param3:GuildInformations = null) : TaxCollectorStaticInformations
      {
         this.firstNameId = param1;
         this.lastNameId = param2;
         this.guildIdentity = param3;
         return this;
      }
      
      public function reset() : void
      {
         this.firstNameId = 0;
         this.lastNameId = 0;
         this.guildIdentity = new GuildInformations();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_TaxCollectorStaticInformations(param1);
      }
      
      public function serializeAs_TaxCollectorStaticInformations(param1:ICustomDataOutput) : void
      {
         if(this.firstNameId < 0)
         {
            throw new Error("Forbidden value (" + this.firstNameId + ") on element firstNameId.");
         }
         param1.writeVarShort(this.firstNameId);
         if(this.lastNameId < 0)
         {
            throw new Error("Forbidden value (" + this.lastNameId + ") on element lastNameId.");
         }
         param1.writeVarShort(this.lastNameId);
         this.guildIdentity.serializeAs_GuildInformations(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TaxCollectorStaticInformations(param1);
      }
      
      public function deserializeAs_TaxCollectorStaticInformations(param1:ICustomDataInput) : void
      {
         this._firstNameIdFunc(param1);
         this._lastNameIdFunc(param1);
         this.guildIdentity = new GuildInformations();
         this.guildIdentity.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TaxCollectorStaticInformations(param1);
      }
      
      public function deserializeAsyncAs_TaxCollectorStaticInformations(param1:FuncTree) : void
      {
         param1.addChild(this._firstNameIdFunc);
         param1.addChild(this._lastNameIdFunc);
         this._guildIdentitytree = param1.addChild(this._guildIdentitytreeFunc);
      }
      
      private function _firstNameIdFunc(param1:ICustomDataInput) : void
      {
         this.firstNameId = param1.readVarUhShort();
         if(this.firstNameId < 0)
         {
            throw new Error("Forbidden value (" + this.firstNameId + ") on element of TaxCollectorStaticInformations.firstNameId.");
         }
      }
      
      private function _lastNameIdFunc(param1:ICustomDataInput) : void
      {
         this.lastNameId = param1.readVarUhShort();
         if(this.lastNameId < 0)
         {
            throw new Error("Forbidden value (" + this.lastNameId + ") on element of TaxCollectorStaticInformations.lastNameId.");
         }
      }
      
      private function _guildIdentitytreeFunc(param1:ICustomDataInput) : void
      {
         this.guildIdentity = new GuildInformations();
         this.guildIdentity.deserializeAsync(this._guildIdentitytree);
      }
   }
}
