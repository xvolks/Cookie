package com.ankamagames.dofus.network.messages.game.actions.fight
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameActionFightSpellCastMessage extends AbstractGameActionFightTargetedAbilityMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 1010;
       
      
      private var _isInitialized:Boolean = false;
      
      public var spellId:uint = 0;
      
      public var spellLevel:int = 0;
      
      public var portalsIds:Vector.<int>;
      
      private var _portalsIdstree:FuncTree;
      
      public function GameActionFightSpellCastMessage()
      {
         this.portalsIds = new Vector.<int>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 1010;
      }
      
      public function initGameActionFightSpellCastMessage(param1:uint = 0, param2:Number = 0, param3:Number = 0, param4:int = 0, param5:uint = 1, param6:Boolean = false, param7:Boolean = false, param8:uint = 0, param9:int = 0, param10:Vector.<int> = null) : GameActionFightSpellCastMessage
      {
         super.initAbstractGameActionFightTargetedAbilityMessage(param1,param2,param3,param4,param5,param6,param7);
         this.spellId = param8;
         this.spellLevel = param9;
         this.portalsIds = param10;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.spellId = 0;
         this.spellLevel = 0;
         this.portalsIds = new Vector.<int>();
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameActionFightSpellCastMessage(param1);
      }
      
      public function serializeAs_GameActionFightSpellCastMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionFightTargetedAbilityMessage(param1);
         if(this.spellId < 0)
         {
            throw new Error("Forbidden value (" + this.spellId + ") on element spellId.");
         }
         param1.writeVarShort(this.spellId);
         if(this.spellLevel < 1 || this.spellLevel > 200)
         {
            throw new Error("Forbidden value (" + this.spellLevel + ") on element spellLevel.");
         }
         param1.writeShort(this.spellLevel);
         param1.writeShort(this.portalsIds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.portalsIds.length)
         {
            param1.writeShort(this.portalsIds[_loc2_]);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionFightSpellCastMessage(param1);
      }
      
      public function deserializeAs_GameActionFightSpellCastMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:int = 0;
         super.deserialize(param1);
         this._spellIdFunc(param1);
         this._spellLevelFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readShort();
            this.portalsIds.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionFightSpellCastMessage(param1);
      }
      
      public function deserializeAsyncAs_GameActionFightSpellCastMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._spellIdFunc);
         param1.addChild(this._spellLevelFunc);
         this._portalsIdstree = param1.addChild(this._portalsIdstreeFunc);
      }
      
      private function _spellIdFunc(param1:ICustomDataInput) : void
      {
         this.spellId = param1.readVarUhShort();
         if(this.spellId < 0)
         {
            throw new Error("Forbidden value (" + this.spellId + ") on element of GameActionFightSpellCastMessage.spellId.");
         }
      }
      
      private function _spellLevelFunc(param1:ICustomDataInput) : void
      {
         this.spellLevel = param1.readShort();
         if(this.spellLevel < 1 || this.spellLevel > 200)
         {
            throw new Error("Forbidden value (" + this.spellLevel + ") on element of GameActionFightSpellCastMessage.spellLevel.");
         }
      }
      
      private function _portalsIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._portalsIdstree.addChild(this._portalsIdsFunc);
            _loc3_++;
         }
      }
      
      private function _portalsIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:int = param1.readShort();
         this.portalsIds.push(_loc2_);
      }
   }
}
