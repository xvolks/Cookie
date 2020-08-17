package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.character.characteristic.CharacterCharacteristicsInformations;
   import com.ankamagames.dofus.network.types.game.data.items.SpellItem;
   import com.ankamagames.dofus.network.types.game.shortcut.Shortcut;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class SlaveSwitchContextMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6214;
       
      
      private var _isInitialized:Boolean = false;
      
      public var masterId:Number = 0;
      
      public var slaveId:Number = 0;
      
      public var slaveSpells:Vector.<SpellItem>;
      
      public var slaveStats:CharacterCharacteristicsInformations;
      
      public var shortcuts:Vector.<Shortcut>;
      
      private var _slaveSpellstree:FuncTree;
      
      private var _slaveStatstree:FuncTree;
      
      private var _shortcutstree:FuncTree;
      
      public function SlaveSwitchContextMessage()
      {
         this.slaveSpells = new Vector.<SpellItem>();
         this.slaveStats = new CharacterCharacteristicsInformations();
         this.shortcuts = new Vector.<Shortcut>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6214;
      }
      
      public function initSlaveSwitchContextMessage(param1:Number = 0, param2:Number = 0, param3:Vector.<SpellItem> = null, param4:CharacterCharacteristicsInformations = null, param5:Vector.<Shortcut> = null) : SlaveSwitchContextMessage
      {
         this.masterId = param1;
         this.slaveId = param2;
         this.slaveSpells = param3;
         this.slaveStats = param4;
         this.shortcuts = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.masterId = 0;
         this.slaveId = 0;
         this.slaveSpells = new Vector.<SpellItem>();
         this.slaveStats = new CharacterCharacteristicsInformations();
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
         this.serializeAs_SlaveSwitchContextMessage(param1);
      }
      
      public function serializeAs_SlaveSwitchContextMessage(param1:ICustomDataOutput) : void
      {
         if(this.masterId < -9007199254740990 || this.masterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.masterId + ") on element masterId.");
         }
         param1.writeDouble(this.masterId);
         if(this.slaveId < -9007199254740990 || this.slaveId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.slaveId + ") on element slaveId.");
         }
         param1.writeDouble(this.slaveId);
         param1.writeShort(this.slaveSpells.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.slaveSpells.length)
         {
            (this.slaveSpells[_loc2_] as SpellItem).serializeAs_SpellItem(param1);
            _loc2_++;
         }
         this.slaveStats.serializeAs_CharacterCharacteristicsInformations(param1);
         param1.writeShort(this.shortcuts.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.shortcuts.length)
         {
            param1.writeShort((this.shortcuts[_loc3_] as Shortcut).getTypeId());
            (this.shortcuts[_loc3_] as Shortcut).serialize(param1);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SlaveSwitchContextMessage(param1);
      }
      
      public function deserializeAs_SlaveSwitchContextMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:SpellItem = null;
         var _loc7_:uint = 0;
         var _loc8_:Shortcut = null;
         this._masterIdFunc(param1);
         this._slaveIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = new SpellItem();
            _loc6_.deserialize(param1);
            this.slaveSpells.push(_loc6_);
            _loc3_++;
         }
         this.slaveStats = new CharacterCharacteristicsInformations();
         this.slaveStats.deserialize(param1);
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = param1.readUnsignedShort();
            _loc8_ = ProtocolTypeManager.getInstance(Shortcut,_loc7_);
            _loc8_.deserialize(param1);
            this.shortcuts.push(_loc8_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SlaveSwitchContextMessage(param1);
      }
      
      public function deserializeAsyncAs_SlaveSwitchContextMessage(param1:FuncTree) : void
      {
         param1.addChild(this._masterIdFunc);
         param1.addChild(this._slaveIdFunc);
         this._slaveSpellstree = param1.addChild(this._slaveSpellstreeFunc);
         this._slaveStatstree = param1.addChild(this._slaveStatstreeFunc);
         this._shortcutstree = param1.addChild(this._shortcutstreeFunc);
      }
      
      private function _masterIdFunc(param1:ICustomDataInput) : void
      {
         this.masterId = param1.readDouble();
         if(this.masterId < -9007199254740990 || this.masterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.masterId + ") on element of SlaveSwitchContextMessage.masterId.");
         }
      }
      
      private function _slaveIdFunc(param1:ICustomDataInput) : void
      {
         this.slaveId = param1.readDouble();
         if(this.slaveId < -9007199254740990 || this.slaveId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.slaveId + ") on element of SlaveSwitchContextMessage.slaveId.");
         }
      }
      
      private function _slaveSpellstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._slaveSpellstree.addChild(this._slaveSpellsFunc);
            _loc3_++;
         }
      }
      
      private function _slaveSpellsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:SpellItem = new SpellItem();
         _loc2_.deserialize(param1);
         this.slaveSpells.push(_loc2_);
      }
      
      private function _slaveStatstreeFunc(param1:ICustomDataInput) : void
      {
         this.slaveStats = new CharacterCharacteristicsInformations();
         this.slaveStats.deserializeAsync(this._slaveStatstree);
      }
      
      private function _shortcutstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._shortcutstree.addChild(this._shortcutsFunc);
            _loc3_++;
         }
      }
      
      private function _shortcutsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:Shortcut = ProtocolTypeManager.getInstance(Shortcut,_loc2_);
         _loc3_.deserialize(param1);
         this.shortcuts.push(_loc3_);
      }
   }
}
