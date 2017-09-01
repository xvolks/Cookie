package com.ankamagames.dofus.network.types.game.guild.tax
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class TaxCollectorInformations implements INetworkType
   {
      
      public static const protocolId:uint = 167;
       
      
      public var uniqueId:int = 0;
      
      public var firtNameId:uint = 0;
      
      public var lastNameId:uint = 0;
      
      public var additionalInfos:AdditionalTaxCollectorInformations;
      
      public var worldX:int = 0;
      
      public var worldY:int = 0;
      
      public var subAreaId:uint = 0;
      
      public var state:uint = 0;
      
      public var look:EntityLook;
      
      public var complements:Vector.<TaxCollectorComplementaryInformations>;
      
      private var _additionalInfostree:FuncTree;
      
      private var _looktree:FuncTree;
      
      private var _complementstree:FuncTree;
      
      public function TaxCollectorInformations()
      {
         this.additionalInfos = new AdditionalTaxCollectorInformations();
         this.look = new EntityLook();
         this.complements = new Vector.<TaxCollectorComplementaryInformations>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 167;
      }
      
      public function initTaxCollectorInformations(param1:int = 0, param2:uint = 0, param3:uint = 0, param4:AdditionalTaxCollectorInformations = null, param5:int = 0, param6:int = 0, param7:uint = 0, param8:uint = 0, param9:EntityLook = null, param10:Vector.<TaxCollectorComplementaryInformations> = null) : TaxCollectorInformations
      {
         this.uniqueId = param1;
         this.firtNameId = param2;
         this.lastNameId = param3;
         this.additionalInfos = param4;
         this.worldX = param5;
         this.worldY = param6;
         this.subAreaId = param7;
         this.state = param8;
         this.look = param9;
         this.complements = param10;
         return this;
      }
      
      public function reset() : void
      {
         this.uniqueId = 0;
         this.firtNameId = 0;
         this.lastNameId = 0;
         this.additionalInfos = new AdditionalTaxCollectorInformations();
         this.worldY = 0;
         this.subAreaId = 0;
         this.state = 0;
         this.look = new EntityLook();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_TaxCollectorInformations(param1);
      }
      
      public function serializeAs_TaxCollectorInformations(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.uniqueId);
         if(this.firtNameId < 0)
         {
            throw new Error("Forbidden value (" + this.firtNameId + ") on element firtNameId.");
         }
         param1.writeVarShort(this.firtNameId);
         if(this.lastNameId < 0)
         {
            throw new Error("Forbidden value (" + this.lastNameId + ") on element lastNameId.");
         }
         param1.writeVarShort(this.lastNameId);
         this.additionalInfos.serializeAs_AdditionalTaxCollectorInformations(param1);
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element worldX.");
         }
         param1.writeShort(this.worldX);
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element worldY.");
         }
         param1.writeShort(this.worldY);
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element subAreaId.");
         }
         param1.writeVarShort(this.subAreaId);
         param1.writeByte(this.state);
         this.look.serializeAs_EntityLook(param1);
         param1.writeShort(this.complements.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.complements.length)
         {
            param1.writeShort((this.complements[_loc2_] as TaxCollectorComplementaryInformations).getTypeId());
            (this.complements[_loc2_] as TaxCollectorComplementaryInformations).serialize(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TaxCollectorInformations(param1);
      }
      
      public function deserializeAs_TaxCollectorInformations(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:TaxCollectorComplementaryInformations = null;
         this._uniqueIdFunc(param1);
         this._firtNameIdFunc(param1);
         this._lastNameIdFunc(param1);
         this.additionalInfos = new AdditionalTaxCollectorInformations();
         this.additionalInfos.deserialize(param1);
         this._worldXFunc(param1);
         this._worldYFunc(param1);
         this._subAreaIdFunc(param1);
         this._stateFunc(param1);
         this.look = new EntityLook();
         this.look.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(TaxCollectorComplementaryInformations,_loc4_);
            _loc5_.deserialize(param1);
            this.complements.push(_loc5_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TaxCollectorInformations(param1);
      }
      
      public function deserializeAsyncAs_TaxCollectorInformations(param1:FuncTree) : void
      {
         param1.addChild(this._uniqueIdFunc);
         param1.addChild(this._firtNameIdFunc);
         param1.addChild(this._lastNameIdFunc);
         this._additionalInfostree = param1.addChild(this._additionalInfostreeFunc);
         param1.addChild(this._worldXFunc);
         param1.addChild(this._worldYFunc);
         param1.addChild(this._subAreaIdFunc);
         param1.addChild(this._stateFunc);
         this._looktree = param1.addChild(this._looktreeFunc);
         this._complementstree = param1.addChild(this._complementstreeFunc);
      }
      
      private function _uniqueIdFunc(param1:ICustomDataInput) : void
      {
         this.uniqueId = param1.readInt();
      }
      
      private function _firtNameIdFunc(param1:ICustomDataInput) : void
      {
         this.firtNameId = param1.readVarUhShort();
         if(this.firtNameId < 0)
         {
            throw new Error("Forbidden value (" + this.firtNameId + ") on element of TaxCollectorInformations.firtNameId.");
         }
      }
      
      private function _lastNameIdFunc(param1:ICustomDataInput) : void
      {
         this.lastNameId = param1.readVarUhShort();
         if(this.lastNameId < 0)
         {
            throw new Error("Forbidden value (" + this.lastNameId + ") on element of TaxCollectorInformations.lastNameId.");
         }
      }
      
      private function _additionalInfostreeFunc(param1:ICustomDataInput) : void
      {
         this.additionalInfos = new AdditionalTaxCollectorInformations();
         this.additionalInfos.deserializeAsync(this._additionalInfostree);
      }
      
      private function _worldXFunc(param1:ICustomDataInput) : void
      {
         this.worldX = param1.readShort();
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element of TaxCollectorInformations.worldX.");
         }
      }
      
      private function _worldYFunc(param1:ICustomDataInput) : void
      {
         this.worldY = param1.readShort();
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element of TaxCollectorInformations.worldY.");
         }
      }
      
      private function _subAreaIdFunc(param1:ICustomDataInput) : void
      {
         this.subAreaId = param1.readVarUhShort();
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element of TaxCollectorInformations.subAreaId.");
         }
      }
      
      private function _stateFunc(param1:ICustomDataInput) : void
      {
         this.state = param1.readByte();
         if(this.state < 0)
         {
            throw new Error("Forbidden value (" + this.state + ") on element of TaxCollectorInformations.state.");
         }
      }
      
      private function _looktreeFunc(param1:ICustomDataInput) : void
      {
         this.look = new EntityLook();
         this.look.deserializeAsync(this._looktree);
      }
      
      private function _complementstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._complementstree.addChild(this._complementsFunc);
            _loc3_++;
         }
      }
      
      private function _complementsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:TaxCollectorComplementaryInformations = ProtocolTypeManager.getInstance(TaxCollectorComplementaryInformations,_loc2_);
         _loc3_.deserialize(param1);
         this.complements.push(_loc3_);
      }
   }
}
