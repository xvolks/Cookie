package com.ankamagames.dofus.network.messages.game.character.choice
{
   import com.ankamagames.dofus.network.types.game.character.choice.CharacterBaseInformations;
   import com.ankamagames.dofus.network.types.game.character.choice.CharacterToRecolorInformation;
   import com.ankamagames.dofus.network.types.game.character.choice.CharacterToRelookInformation;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CharactersListWithModificationsMessage extends CharactersListMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6120;
       
      
      private var _isInitialized:Boolean = false;
      
      public var charactersToRecolor:Vector.<CharacterToRecolorInformation>;
      
      public var charactersToRename:Vector.<int>;
      
      public var unusableCharacters:Vector.<int>;
      
      public var charactersToRelook:Vector.<CharacterToRelookInformation>;
      
      private var _charactersToRecolortree:FuncTree;
      
      private var _charactersToRenametree:FuncTree;
      
      private var _unusableCharacterstree:FuncTree;
      
      private var _charactersToRelooktree:FuncTree;
      
      public function CharactersListWithModificationsMessage()
      {
         this.charactersToRecolor = new Vector.<CharacterToRecolorInformation>();
         this.charactersToRename = new Vector.<int>();
         this.unusableCharacters = new Vector.<int>();
         this.charactersToRelook = new Vector.<CharacterToRelookInformation>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6120;
      }
      
      public function initCharactersListWithModificationsMessage(param1:Vector.<CharacterBaseInformations> = null, param2:Boolean = false, param3:Vector.<CharacterToRecolorInformation> = null, param4:Vector.<int> = null, param5:Vector.<int> = null, param6:Vector.<CharacterToRelookInformation> = null) : CharactersListWithModificationsMessage
      {
         super.initCharactersListMessage(param1,param2);
         this.charactersToRecolor = param3;
         this.charactersToRename = param4;
         this.unusableCharacters = param5;
         this.charactersToRelook = param6;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.charactersToRecolor = new Vector.<CharacterToRecolorInformation>();
         this.charactersToRename = new Vector.<int>();
         this.unusableCharacters = new Vector.<int>();
         this.charactersToRelook = new Vector.<CharacterToRelookInformation>();
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
         this.serializeAs_CharactersListWithModificationsMessage(param1);
      }
      
      public function serializeAs_CharactersListWithModificationsMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_CharactersListMessage(param1);
         param1.writeShort(this.charactersToRecolor.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.charactersToRecolor.length)
         {
            (this.charactersToRecolor[_loc2_] as CharacterToRecolorInformation).serializeAs_CharacterToRecolorInformation(param1);
            _loc2_++;
         }
         param1.writeShort(this.charactersToRename.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.charactersToRename.length)
         {
            param1.writeInt(this.charactersToRename[_loc3_]);
            _loc3_++;
         }
         param1.writeShort(this.unusableCharacters.length);
         var _loc4_:uint = 0;
         while(_loc4_ < this.unusableCharacters.length)
         {
            param1.writeInt(this.unusableCharacters[_loc4_]);
            _loc4_++;
         }
         param1.writeShort(this.charactersToRelook.length);
         var _loc5_:uint = 0;
         while(_loc5_ < this.charactersToRelook.length)
         {
            (this.charactersToRelook[_loc5_] as CharacterToRelookInformation).serializeAs_CharacterToRelookInformation(param1);
            _loc5_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharactersListWithModificationsMessage(param1);
      }
      
      public function deserializeAs_CharactersListWithModificationsMessage(param1:ICustomDataInput) : void
      {
         var _loc10_:CharacterToRecolorInformation = null;
         var _loc11_:int = 0;
         var _loc12_:int = 0;
         var _loc13_:CharacterToRelookInformation = null;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc10_ = new CharacterToRecolorInformation();
            _loc10_.deserialize(param1);
            this.charactersToRecolor.push(_loc10_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc11_ = param1.readInt();
            this.charactersToRename.push(_loc11_);
            _loc5_++;
         }
         var _loc6_:uint = param1.readUnsignedShort();
         var _loc7_:uint = 0;
         while(_loc7_ < _loc6_)
         {
            _loc12_ = param1.readInt();
            this.unusableCharacters.push(_loc12_);
            _loc7_++;
         }
         var _loc8_:uint = param1.readUnsignedShort();
         var _loc9_:uint = 0;
         while(_loc9_ < _loc8_)
         {
            _loc13_ = new CharacterToRelookInformation();
            _loc13_.deserialize(param1);
            this.charactersToRelook.push(_loc13_);
            _loc9_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharactersListWithModificationsMessage(param1);
      }
      
      public function deserializeAsyncAs_CharactersListWithModificationsMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._charactersToRecolortree = param1.addChild(this._charactersToRecolortreeFunc);
         this._charactersToRenametree = param1.addChild(this._charactersToRenametreeFunc);
         this._unusableCharacterstree = param1.addChild(this._unusableCharacterstreeFunc);
         this._charactersToRelooktree = param1.addChild(this._charactersToRelooktreeFunc);
      }
      
      private function _charactersToRecolortreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._charactersToRecolortree.addChild(this._charactersToRecolorFunc);
            _loc3_++;
         }
      }
      
      private function _charactersToRecolorFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:CharacterToRecolorInformation = new CharacterToRecolorInformation();
         _loc2_.deserialize(param1);
         this.charactersToRecolor.push(_loc2_);
      }
      
      private function _charactersToRenametreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._charactersToRenametree.addChild(this._charactersToRenameFunc);
            _loc3_++;
         }
      }
      
      private function _charactersToRenameFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:int = param1.readInt();
         this.charactersToRename.push(_loc2_);
      }
      
      private function _unusableCharacterstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._unusableCharacterstree.addChild(this._unusableCharactersFunc);
            _loc3_++;
         }
      }
      
      private function _unusableCharactersFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:int = param1.readInt();
         this.unusableCharacters.push(_loc2_);
      }
      
      private function _charactersToRelooktreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._charactersToRelooktree.addChild(this._charactersToRelookFunc);
            _loc3_++;
         }
      }
      
      private function _charactersToRelookFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:CharacterToRelookInformation = new CharacterToRelookInformation();
         _loc2_.deserialize(param1);
         this.charactersToRelook.push(_loc2_);
      }
   }
}
