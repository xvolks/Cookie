package com.ankamagames.dofus.network.messages.game.guild
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GuildInfosUpgradeMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5636;
       
      
      private var _isInitialized:Boolean = false;
      
      public var maxTaxCollectorsCount:uint = 0;
      
      public var taxCollectorsCount:uint = 0;
      
      public var taxCollectorLifePoints:uint = 0;
      
      public var taxCollectorDamagesBonuses:uint = 0;
      
      public var taxCollectorPods:uint = 0;
      
      public var taxCollectorProspecting:uint = 0;
      
      public var taxCollectorWisdom:uint = 0;
      
      public var boostPoints:uint = 0;
      
      public var spellId:Vector.<uint>;
      
      public var spellLevel:Vector.<int>;
      
      private var _spellIdtree:FuncTree;
      
      private var _spellLeveltree:FuncTree;
      
      public function GuildInfosUpgradeMessage()
      {
         this.spellId = new Vector.<uint>();
         this.spellLevel = new Vector.<int>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5636;
      }
      
      public function initGuildInfosUpgradeMessage(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0, param5:uint = 0, param6:uint = 0, param7:uint = 0, param8:uint = 0, param9:Vector.<uint> = null, param10:Vector.<int> = null) : GuildInfosUpgradeMessage
      {
         this.maxTaxCollectorsCount = param1;
         this.taxCollectorsCount = param2;
         this.taxCollectorLifePoints = param3;
         this.taxCollectorDamagesBonuses = param4;
         this.taxCollectorPods = param5;
         this.taxCollectorProspecting = param6;
         this.taxCollectorWisdom = param7;
         this.boostPoints = param8;
         this.spellId = param9;
         this.spellLevel = param10;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.maxTaxCollectorsCount = 0;
         this.taxCollectorsCount = 0;
         this.taxCollectorLifePoints = 0;
         this.taxCollectorDamagesBonuses = 0;
         this.taxCollectorPods = 0;
         this.taxCollectorProspecting = 0;
         this.taxCollectorWisdom = 0;
         this.boostPoints = 0;
         this.spellId = new Vector.<uint>();
         this.spellLevel = new Vector.<int>();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GuildInfosUpgradeMessage(param1);
      }
      
      public function serializeAs_GuildInfosUpgradeMessage(param1:ICustomDataOutput) : void
      {
         if(this.maxTaxCollectorsCount < 0)
         {
            throw new Error("Forbidden value (" + this.maxTaxCollectorsCount + ") on element maxTaxCollectorsCount.");
         }
         param1.writeByte(this.maxTaxCollectorsCount);
         if(this.taxCollectorsCount < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorsCount + ") on element taxCollectorsCount.");
         }
         param1.writeByte(this.taxCollectorsCount);
         if(this.taxCollectorLifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorLifePoints + ") on element taxCollectorLifePoints.");
         }
         param1.writeVarShort(this.taxCollectorLifePoints);
         if(this.taxCollectorDamagesBonuses < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorDamagesBonuses + ") on element taxCollectorDamagesBonuses.");
         }
         param1.writeVarShort(this.taxCollectorDamagesBonuses);
         if(this.taxCollectorPods < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorPods + ") on element taxCollectorPods.");
         }
         param1.writeVarShort(this.taxCollectorPods);
         if(this.taxCollectorProspecting < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorProspecting + ") on element taxCollectorProspecting.");
         }
         param1.writeVarShort(this.taxCollectorProspecting);
         if(this.taxCollectorWisdom < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorWisdom + ") on element taxCollectorWisdom.");
         }
         param1.writeVarShort(this.taxCollectorWisdom);
         if(this.boostPoints < 0)
         {
            throw new Error("Forbidden value (" + this.boostPoints + ") on element boostPoints.");
         }
         param1.writeVarShort(this.boostPoints);
         param1.writeShort(this.spellId.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.spellId.length)
         {
            if(this.spellId[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.spellId[_loc2_] + ") on element 9 (starting at 1) of spellId.");
            }
            param1.writeVarShort(this.spellId[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.spellLevel.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.spellLevel.length)
         {
            param1.writeShort(this.spellLevel[_loc3_]);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildInfosUpgradeMessage(param1);
      }
      
      public function deserializeAs_GuildInfosUpgradeMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:int = 0;
         this._maxTaxCollectorsCountFunc(param1);
         this._taxCollectorsCountFunc(param1);
         this._taxCollectorLifePointsFunc(param1);
         this._taxCollectorDamagesBonusesFunc(param1);
         this._taxCollectorPodsFunc(param1);
         this._taxCollectorProspectingFunc(param1);
         this._taxCollectorWisdomFunc(param1);
         this._boostPointsFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readVarUhShort();
            if(_loc6_ < 0)
            {
               throw new Error("Forbidden value (" + _loc6_ + ") on elements of spellId.");
            }
            this.spellId.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = param1.readShort();
            this.spellLevel.push(_loc7_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildInfosUpgradeMessage(param1);
      }
      
      public function deserializeAsyncAs_GuildInfosUpgradeMessage(param1:FuncTree) : void
      {
         param1.addChild(this._maxTaxCollectorsCountFunc);
         param1.addChild(this._taxCollectorsCountFunc);
         param1.addChild(this._taxCollectorLifePointsFunc);
         param1.addChild(this._taxCollectorDamagesBonusesFunc);
         param1.addChild(this._taxCollectorPodsFunc);
         param1.addChild(this._taxCollectorProspectingFunc);
         param1.addChild(this._taxCollectorWisdomFunc);
         param1.addChild(this._boostPointsFunc);
         this._spellIdtree = param1.addChild(this._spellIdtreeFunc);
         this._spellLeveltree = param1.addChild(this._spellLeveltreeFunc);
      }
      
      private function _maxTaxCollectorsCountFunc(param1:ICustomDataInput) : void
      {
         this.maxTaxCollectorsCount = param1.readByte();
         if(this.maxTaxCollectorsCount < 0)
         {
            throw new Error("Forbidden value (" + this.maxTaxCollectorsCount + ") on element of GuildInfosUpgradeMessage.maxTaxCollectorsCount.");
         }
      }
      
      private function _taxCollectorsCountFunc(param1:ICustomDataInput) : void
      {
         this.taxCollectorsCount = param1.readByte();
         if(this.taxCollectorsCount < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorsCount + ") on element of GuildInfosUpgradeMessage.taxCollectorsCount.");
         }
      }
      
      private function _taxCollectorLifePointsFunc(param1:ICustomDataInput) : void
      {
         this.taxCollectorLifePoints = param1.readVarUhShort();
         if(this.taxCollectorLifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorLifePoints + ") on element of GuildInfosUpgradeMessage.taxCollectorLifePoints.");
         }
      }
      
      private function _taxCollectorDamagesBonusesFunc(param1:ICustomDataInput) : void
      {
         this.taxCollectorDamagesBonuses = param1.readVarUhShort();
         if(this.taxCollectorDamagesBonuses < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorDamagesBonuses + ") on element of GuildInfosUpgradeMessage.taxCollectorDamagesBonuses.");
         }
      }
      
      private function _taxCollectorPodsFunc(param1:ICustomDataInput) : void
      {
         this.taxCollectorPods = param1.readVarUhShort();
         if(this.taxCollectorPods < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorPods + ") on element of GuildInfosUpgradeMessage.taxCollectorPods.");
         }
      }
      
      private function _taxCollectorProspectingFunc(param1:ICustomDataInput) : void
      {
         this.taxCollectorProspecting = param1.readVarUhShort();
         if(this.taxCollectorProspecting < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorProspecting + ") on element of GuildInfosUpgradeMessage.taxCollectorProspecting.");
         }
      }
      
      private function _taxCollectorWisdomFunc(param1:ICustomDataInput) : void
      {
         this.taxCollectorWisdom = param1.readVarUhShort();
         if(this.taxCollectorWisdom < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorWisdom + ") on element of GuildInfosUpgradeMessage.taxCollectorWisdom.");
         }
      }
      
      private function _boostPointsFunc(param1:ICustomDataInput) : void
      {
         this.boostPoints = param1.readVarUhShort();
         if(this.boostPoints < 0)
         {
            throw new Error("Forbidden value (" + this.boostPoints + ") on element of GuildInfosUpgradeMessage.boostPoints.");
         }
      }
      
      private function _spellIdtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._spellIdtree.addChild(this._spellIdFunc);
            _loc3_++;
         }
      }
      
      private function _spellIdFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of spellId.");
         }
         this.spellId.push(_loc2_);
      }
      
      private function _spellLeveltreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._spellLeveltree.addChild(this._spellLevelFunc);
            _loc3_++;
         }
      }
      
      private function _spellLevelFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:int = param1.readShort();
         this.spellLevel.push(_loc2_);
      }
   }
}
